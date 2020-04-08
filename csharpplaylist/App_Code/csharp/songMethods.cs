using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace csharpplaylist.App_Code.csharp
{
    public class songMethods
    {
        DataSet ds;
        string filename;

        public DataSet GetPlaylist(string file)
        {
            filename = file;
            ds = new DataSet("playlist");

            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcFile = new DataColumn("file");

            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcFile);
            ds.Tables.Add(dtSongs);

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/xmlfiles/" + filename));

            return ds;
        }
        public void DeleteSong(string id)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + "'");
            if (drArray != null && drArray.Length > 0)
            {
                drArray[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath("~/App_Data/xmlfiles/" + filename));
            }
        }

        public DataRow CreateEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public DataRow UpdateSong(string id)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + "'");
            if (drArray != null && drArray.Length > 0)
            {
                return drArray[0];
            } 
            else
            {
                return null;
            }

        }

        public void CreateSong(DataRow dr)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(HttpContext.Current.Server.MapPath("~/App_data/xmlfiles/" + filename));
        }
    }
}