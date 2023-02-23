Imports System
Imports System.Data
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.Office
Imports DevExpress.XtraRichEdit

Namespace ASPxRichEditBinding

    Public Partial Class [Default]
        Inherits Page

        Private SessionKey As String = "EditedDocuemntID"

        Protected Property EditedDocuemntID As String
            Get
                Return If(CStr(Session(SessionKey)), String.Empty)
            End Get

            Set(ByVal value As String)
                Session(SessionKey) = value
            End Set
        End Property

        Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            RichEdit.Save()
        End Sub

        Protected Sub OpenFromStreamBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not String.IsNullOrEmpty(EditedDocuemntID) Then
                Call DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocuemntID).DocumentId)
                EditedDocuemntID = String.Empty
            End If

            Dim view As DataView = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
            EditedDocuemntID = view.Table.Rows(0)("Id").ToString() ' Guid type
            If view.Count <> 0 Then RichEdit.Open(EditedDocuemntID, DocumentFormat.Rtf, Function()
                Dim docBytes As Byte() = CType(view.Table.Rows(0)("DocBytes"), Byte())
                Return New MemoryStream(docBytes)
            End Function)
        End Sub

        Protected Sub OpenFromByteArrayBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not String.IsNullOrEmpty(EditedDocuemntID) Then
                Call DocumentManager.CloseDocument(DocumentManager.FindDocument(EditedDocuemntID).DocumentId)
                EditedDocuemntID = String.Empty
            End If

            Dim view As DataView = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
            If view.Count <> 0 Then EditedDocuemntID = view.Table.Rows(0)("Id").ToString() ' Guid type
            RichEdit.Open(EditedDocuemntID, DocumentFormat.Rtf, Function() CType(view.Table.Rows(0)("DocBytes"), Byte()))
        End Sub

        Protected Sub RichEdit_Saving(ByVal source As Object, ByVal e As DocumentSavingEventArgs)
            ' Save document with the Ribbon Save button
            e.Handled = True
            SqlDataSource1.Update()
        End Sub

        Protected Sub SqlDataSource1_Updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
            e.Cancel = Equals(RichEdit.DocumentId, String.Empty) 'Save only opened documents
            e.Command.Parameters("@Id").Value = RichEdit.DocumentId
            e.Command.Parameters("@DocBytes").Value = RichEdit.SaveCopy(DocumentFormat.Rtf)
        End Sub
    End Class
End Namespace
