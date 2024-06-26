<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128545498/15.2.11%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T352034)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Rich Text Editor for ASP.NET Web Forms - How to save/load documents to/from a database

This example demonstrates how to configure the [Rich Text Editor](https://docs.devexpress.com/AspNet/17721/components/rich-text-editor) control to work with a database.

![Connect Rich Text Editor to Database](work-with-database.gif)

Load a document from a database as a byte array and pass it to the control's [Open(String, DocumentFormat, Func<Byte[]>)](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit.Open(System.String-DevExpress.XtraRichEdit.DocumentFormat-System.Func-System.Byte---)) method overload to open the document in the Rich Text Editor. The [Open(String, DocumentFormat, Func\<Stream\>)](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit.Open(System.String-DevExpress.XtraRichEdit.DocumentFormat-System.Func-System.IO.Stream-)) method overload allows you to open a document loaded from the database as a stream.

The [Saving](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit.Saving) event occurs when you call the [Save](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxRichEdit.ASPxRichEdit.Save) method or a user clicks the built-in **Save** or **SaveAs** command in the Ribbon UI. To save changes, handle the `Saving` event and update the data source.

## Files to Review

* [Default.aspx](./CS/ASPxRichEdit_Binding/Default.aspx) (VB: [Default.aspx](./VB/ASPxRichEdit_Binding/Default.aspx))
* [Default.aspx.cs](./CS/ASPxRichEdit_Binding/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ASPxRichEdit_Binding/Default.aspx.vb))

## Documentation

* [RichEdit Document Management](https://docs.devexpress.com/AspNet/401562/components/rich-text-editor/document-management)
* [Querying Data with the SqlDataSource Control](https://learn.microsoft.com/en-us/aspnet/web-forms/overview/data-access/accessing-the-database-directly-from-an-aspnet-page/querying-data-with-the-sqldatasource-control-cs)

## More Examples

* [Rich Text Editor for ASP.NET MVC - How to save/load documents from/to a database](https://github.com/DevExpress-Examples/mvc-richedit-save-and-load-documents-from-a-database)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-richedit-work-with-database&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-richedit-work-with-database&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
