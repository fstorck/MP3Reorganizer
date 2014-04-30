using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Threading;

using System.Security.Cryptography;

namespace MP3TagRename
{
    public partial class MainFrm : Form
    {
        bool _bAbort = false;

        int   _EqualFiles     = 0;
        long  _BytesProcessed = 0;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void BTN_StartProcessing_Click(object sender, EventArgs e)
        {
            _bAbort         = false;
            _EqualFiles     = 0;
            _BytesProcessed = 0;
            PGB_Files.Value = 0;

            BTN_SelectSrcDir.Enabled    = false;
            BTN_SelectDstDir.Enabled    = false;
            BTN_StartProcessing.Enabled = false;

            ThreadPool.QueueUserWorkItem(new WaitCallback(WCB_Process));
        }

        void OnFinishedProcessing()
        {
            _bAbort = false;
            PGB_Files.Value = 0;

            BTN_SelectSrcDir.Enabled    = true;
            BTN_SelectDstDir.Enabled    = true;
            BTN_StartProcessing.Enabled = true;
        }

        private void BTN_SelectSrcDir_Click(object sender, EventArgs e)
        {
            if(FBD_SrcDir.ShowDialog() == DialogResult.OK)
            {
                LBL_SrcDir.Text = FBD_SrcDir.SelectedPath;
            }
        }

        private void BTN_SelectDstDir_Click(object sender, EventArgs e)
        {
            if(FBD_DstDir.ShowDialog() == DialogResult.OK)
            {
                LBL_DstDir.Text = FBD_DstDir.SelectedPath;
            }
        }

        private void BTN_Abort_Click(object sender, EventArgs e)
        {
            _bAbort = true;
        }

        void WCB_Process(object state)
        {
            try
            {
                if ((FBD_SrcDir.SelectedPath != "") && (FBD_DstDir.SelectedPath != ""))
                {
                    DirectoryInfo diSrc = new DirectoryInfo(FBD_SrcDir.SelectedPath);
                    FileInfo[] mp3Files = diSrc.GetFiles("*.mp3", SearchOption.AllDirectories);


                    int NumFiles = mp3Files.Length;

                    for (int i = 0; i < NumFiles; i++)
                    {
                        FileInfo fi = mp3Files[i];

                        if (_bAbort)
                            return;

                        ProcessFile(NumFiles, i, fi);
                    }
                }
            }
            catch (System.Exception ex)
            {
                AsyncUI.Call(RTB_Errors, delegate
                {
                    RTB_Errors.Text = string.Format("ERROR: {0}", ex.Message);
                });
            }
            finally
            {
                AsyncUI.Call(this, delegate
                {
                    OnFinishedProcessing();
                });
            }
       
        }

        private void ProcessFile(int NumFiles, int i, FileInfo fi)
        {
            try
            {
                TagLib.File file = TagLib.Audible.File.Create(fi.FullName);

                TagLib.Mpeg.AudioFile mp3 = file as TagLib.Mpeg.AudioFile;

                string sArtist = "";
                string sAlbum = "";
                string sTrack = "";
                string sKbps = "";

                sKbps = string.Format("{0}kbps", mp3.Properties.AudioBitrate.ToString());

                StringBuilder sbTrack = new StringBuilder();

                if (mp3.Tag.Album != null)
                    sAlbum = mp3.Tag.Album;

                if (mp3.Tag.FirstPerformer != null)
                    sArtist = mp3.Tag.FirstPerformer;

                if (mp3.Tag.Track > 0)
                    sTrack = string.Format("{0:D2}", mp3.Tag.Track);

                string sTitle = "";
                if (mp3.Tag.Title != null)
                    sTitle = mp3.Tag.Title;

                sTitle  = LegalizePath(sTitle);
                sAlbum  = LegalizePath(sAlbum);
                sArtist = LegalizePath(sArtist);

                StringBuilder sbTrackName = new StringBuilder();
                StringBuilder sbPath = new StringBuilder();

                if (sTrack != "")
                {
                    sbTrackName = sbTrackName.Append(sTrack);
                }

                if (sArtist != "")
                {
                    sbTrackName.AppendFormat("-{0}", sArtist);
                    sbPath.AppendFormat("{0}\\", sArtist);

                }

                if (sAlbum != "")
                {
                    sbTrackName.AppendFormat("-[{0}]", sAlbum);
                    sbPath.AppendFormat("{0}\\", sAlbum);
                }

                if (sTitle != "")
                    sbTrackName.AppendFormat("-{0}", sTitle);

                sbTrackName.AppendFormat(".{0}", sKbps);

                string sTrackName = sbTrackName.ToString();
                /*
                sTrackName = string.Format("{0}-{1}-{2}-{3}.{4}",
                    sTrack, sArtist, sAlbum, sTitle, sKbps);
                */
                // DstPath/Artist/Album/Track-Artist-Album-[kbps].mp3
                string sDstPath = Path.Combine(FBD_DstDir.SelectedPath, sbPath.ToString());

                string sDstFile = Path.Combine(sDstPath, sTrackName);

                UpdateProgress(i, NumFiles, fi.FullName, sDstFile);

                if (!Directory.Exists(sDstPath))
                    Directory.CreateDirectory(sDstPath);

                int cnt = 0;
                string sDst = sDstFile + ".mp3";
                bool bIsSameFile = false;

                while (System.IO.File.Exists(sDst) && !bIsSameFile)
                {
                    if (!CompareFilesByHash(fi.FullName, sDst))
                    {
                        cnt++;
                        sDst = string.Format("{0}({1}).mp3", Path.Combine(sDstPath, sTrackName), cnt);
                    }
                    else
                    {
                        bIsSameFile = true;
                        _EqualFiles++;
                    }
                }


                if (!bIsSameFile)
                    System.IO.File.Copy(fi.FullName, sDst);

                _BytesProcessed += fi.Length;

            }
            catch (System.Exception ex)
            {
                AsyncUI.Call(RTB_Errors, delegate
                {
                    RTB_Errors.Text = string.Format("ERROR: {0}", ex.Message);
                });
            }
        }


        void UpdateProgress(int i, int NumFiles, string SrcFull, string DstFull)
        {
            AsyncUI.Call(RTB_Log, delegate
            {

                LBL_NumFiles.Text = string.Format("{0} / {1}", i + 1, NumFiles);

                double pg = ((i + 1) * 100.0) / NumFiles;
                PGB_Files.Value = (int)pg;

                string sMsg = string.Format("Processing: {0,60}\r\n", SrcFull);
                sMsg += string.Format("Copy To: {0}", DstFull);
                RTB_Log.AppendText(sMsg);

                string sStats  = string.Format("Equal Files: {0,3} [not copied] / Processed {1,6} MBytes", _EqualFiles, _BytesProcessed / 1048576);
                LBL_Stats.Text = sStats; 

            });
        }

        bool CompareFilesByHash(string Src, string Dst)
        {
            byte[] SrcMD5 = GetFileHash(Src);
            byte[] DstMD5 = GetFileHash(Dst);

            return
                SrcMD5.SequenceEqual(DstMD5);
        }

        byte[] GetFileHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        string LegalizePath(string Src)
        {
            // string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                Src = Src.Replace(c.ToString(), "");
            }
            return
                Src;
        }

        private void BTN_ScanFiles_Click(object sender, EventArgs e)
        {
            if (FBD_SrcDir.ShowDialog() == DialogResult.OK)
            {
                LBL_SrcDir.Text = FBD_SrcDir.SelectedPath;
                DirectoryInfo diSrc = new DirectoryInfo(FBD_SrcDir.SelectedPath);
                FileInfo[] Files = diSrc.GetFiles("*.*", SearchOption.AllDirectories);

                LBX_Files.DataSource = Files;
                /*
                int NumFiles = Files.Length;

                for (int i = 0; i < NumFiles; i++)
                {
                    FileInfo fi = Files[i];

                    if (_bAbort)
                        return;

                    try
                    {
                    
                        using (TagLib.File file = TagLib.File.Create(fi.FullName))
                        {

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
                */
            }
        }

        private void LBX_Files_SelectedValueChanged(object sender, EventArgs e)
        {
            FileInfo fi = (FileInfo)LBX_Files.SelectedItem;
            if (fi != null)
            {
                try
                {
                    TagLib.File file = TagLib.File.Create(fi.FullName);
                    PGD_TagInfo.SelectedObject = file.Tag;
                }
                catch (Exception ex)
                {

                }

            }
        }
    }
    /// <summary>
    /// Implements a simplified pattern for handling 
    /// cross-thread invocation from UI controls.
    /// </summary>
    public static class AsyncUI
    {
        public static void Call(Control ctl, MethodInvoker fn)
        {
            if (ctl.InvokeRequired)
            {
                ctl.BeginInvoke(fn);
                return;
            }

            fn.Invoke();
        }
    }
}
