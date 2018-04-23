using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Office;
using DevExpress.XtraRichEdit;

namespace ASPxRichEditBinding {
    public partial class Default : System.Web.UI.Page {
        string SessionKey = "EditedDocuemntID";
        protected string EditedDocuemntID {
            get { return (string)Session[SessionKey] ?? string.Empty; }
            set { Session[SessionKey] = value; }
        }
        protected void SaveButton_Click(object sender, EventArgs e) {
            RichEdit.Save();
        }

        protected void OpenFromStreamBtn_Click(object sender, EventArgs e) {
            if(!string.IsNullOrEmpty(EditedDocuemntID)) {
                DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocuemntID).DocumentId);
                EditedDocuemntID = string.Empty;
            }
            DataView view = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            EditedDocuemntID = view.Table.Rows[0]["Id"].ToString(); // Guid type
            if(view.Count != 0)
                RichEdit.Open(
                    EditedDocuemntID,
                    DocumentFormat.Rtf,
                    () => {
                        byte[] docBytes = (byte[])view.Table.Rows[0]["DocBytes"];
                        return new MemoryStream(docBytes);
                    }
                );
        }

        protected void OpenFromByteArrayBtn_Click(object sender, EventArgs e) {
            if(!string.IsNullOrEmpty(EditedDocuemntID)) {
                DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocuemntID).DocumentId);
                EditedDocuemntID = string.Empty;
            }
            DataView view = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if(view.Count != 0)
                EditedDocuemntID = view.Table.Rows[0]["Id"].ToString(); // Guid type
                RichEdit.Open(
                    EditedDocuemntID,
                    DocumentFormat.Rtf,
                    () => { return (byte[])view.Table.Rows[0]["DocBytes"]; }
                );
        }

        protected void RichEdit_Saving(object source, DocumentSavingEventArgs e) {
            // Save document with the Ribbon Save button
            e.Handled = true;
            SqlDataSource1.Update();
        }

        protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e) {
            e.Cancel = RichEdit.DocumentId == string.Empty; //Save only opened documents
            e.Command.Parameters["@Id"].Value = RichEdit.DocumentId;
            e.Command.Parameters["@DocBytes"].Value = RichEdit.SaveCopy(DocumentFormat.Rtf);
        }
    }
}