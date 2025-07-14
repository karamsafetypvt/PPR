/*const { Toast } = require("bootstrap");*/

var getid = 0;
var href;
$(document).ready(function () {
    var getQueryString = function (field, url) {
        var href = url ? url : window.location.href;
        var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
        var string = reg.exec(href);
        return string ? string[1] : null;
    };
    getid = getQueryString('ProjectID');
})

function GetDevelopmentSheetReport() {

    $("#partialDivds").empty();
    $.ajax(
        {
            type: 'Get',
            url: '/Reports/GetDevelopmentSheetReport',
            beforeSend: function () {
                /* $('.page-loader-wrapper').show();*/
            },
            complete: function () {
                /*$('.page-loader-wrapper').hide();*/
            },
            success:
                function (response) {

                    var html = '';
                    if (response != "") {
                        var List = $.parseJSON(response);

                        //-----------------------------Development Plan-------------------------
                        html += '<div class="span12 table2excel" id="PPRDDSheets"style="text-align:center" data-SheetName="Design Development Sheet" >';
                        /*  html += '<h1>DESIGN DEVELOPMENT SHEET</h1> '*/

                        html += '<table class="table">'
                        html += '<thead>';
                        html += '<tr>';
                        html += '<td colspan="18"><img src="' + List[0].Url +'/img/karamlogo.png" alt="Logo" style="width:50px;height:50px"></td>';
                        html += '</tr><tr><td colspan="18"></td></tr><tr><td colspan="7"></td><td  colspan="9"><h1>DESIGN DEVELOPMENT SHEET</h1></td></tr><tr><td colspan="18"></td></tr><tr><td colspan="12"></td></tr>';
                        html += '<thead></table> ';

                        html += '<table class="table table table-bordered" style="border:1px solid black">'
                        html += '<thead>';
                        html += '<tr>';
                        html += '<th  style="border:1px solid black">Sr. No.</th>';
                        html += '<th  style="border:1px solid black">New Product Description</th>';
                        html += '<th  style="border:1px solid black">Picture</th>';
                        html += '<th  style="border:1px solid black">Ref.No.</th>';
                        html += '<th  style="border:1px solid black">PPRNo.</th>';
                        html += '<th  style="border:1px solid black">Activity Name</th>';
                        html += '<th  style="border:1px solid black">Status of current actions under plan</th>';
                        html += '<th  style="border:1px solid black">Customer</th>';
                        html += '<th  style="border:1px solid black">Resp</th>';
                        html += '<th  style="border:1px solid black">Target Date</th>';
                        html += '<th  style="border:1px solid black">Revised Date </th>';
                        html += '<th  style="border:1px solid black">Certification Status</th>';
                        html += '<th  style="border:1px solid black">Sample to be sent for trial (KRATOS & Gary)</th>';
                        html += '<th  style="border:1px solid black">Item creation, BOM & Routing</th>';
                        html += '<th  style="border:1px solid black">Translation Status</th>';
                        html += '<th  style="border:1px solid black">REMARK</th>';
                        html += '</tr>';
                        html += '</thead>';
                        html += '<tbody>';
                        for (var j = 0; j < List.length; j++) {
                            var result = List[j];
                            var DevelopmentList = result.DevelopmentSheet;
                           
                            for (var i = 0; i < DevelopmentList.length; i++) {
                                var data = DevelopmentList[i];
                                html += '<tr><td colspan="16" style="border:1px solid black;text-align:center"><b>' + result.Product_Category + '</b></td></tr>';
                                html += '<tr>';
                                html += '<td style="border:1px solid black">' + Number(j + 1) + '</td>';
                                html += '<td style="border:1px solid black">' + result.ProductDescription + '</td>';
                                html += '<td style="border:1px solid black"><img src=' + result.ImagePath + ' width="30" height="30"></td>';
                                html += '<td style="border:1px solid black">' + result.Product_Ref_No + '</td>';
                                html += '<td style="border:1px solid black">' + result.ProjectNumber + '</td>';
                                html += '<td colspan="11" style="border:1px solid black">'; 
                                html += '<table class="table">'
                               
                                for (i = 0; i < DevelopmentList.length; i++) { 
                                    var data = DevelopmentList[i];
                                    html += '<tr> '
                                    html += '<td style="border:1px solid black"> ' + data.ActivityName + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.Statusofcurrentactionsunderplan + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.Customer + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.Responsibility + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.TargetDate + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.CompletionDate + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.CertificationStatus + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.Sampletobesentfortrial + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.ItemcreationBOMRouting + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.TranslationStatus + '</td>';
                                    html += '<td style="border:1px solid black"> ' + data.Remark + '</td>'; 
                                    html += '</tr>' 
                                } 
                                html += '</table>'
                                html += '</td>';
                                html += '</tr>';
                            } 
                        } 
                        html += '</tbody>';
                        html += '</table >';
                        html += '</div >';

                    }
                    else {
                        html += '<div class="text-center"><span>No data found.</span></div>';
                    }
                    $("#partialDivds").append(html);
                    Idname = '';

                    $("#partialDivds").each(function () {
                        var images = $(this).find(".table2excel");

                        for (var m = 0; m < images.length; m++) {
                            if (m == images.length) {
                                Idname += '#' + images[m].id;
                            } else {
                                Idname += '#' + images[m].id + ',';
                            }
                            var dd = images[m].id;
                            var txt = dd;
                        }
                        Idname = Idname.replace(/,\s*$/, "");
                        if (images.length > 0) {
                            tablesToExcel(Idname, 'Development Sheet.xls');
                        }
                    });
                },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });
}
var tablesToExcel = (function ($) {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , html_start = `<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">`
        , template_ExcelWorksheet = `<x:ExcelWorksheet><x:Name>{SheetName}</x:Name><x:WorksheetSource HRef="sheet{SheetIndex}.htm"/></x:ExcelWorksheet>`
        , template_ListWorksheet = `<o:File HRef="sheet{SheetIndex}.htm"/>`
        , template_HTMLWorksheet = `
------=_NextPart_dummy
Content-Location: sheet{SheetIndex}.htm
Content-Type: text/html; charset=windows-1252

` + html_start + `
<head>
            <meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
            <link id="Main-File" rel="Main-File" href="../WorkBook.htm">
            <link rel="File-List" href="filelist.xml">
</head>
<body><table>{SheetContent}</table></body>
</html>`
        , template_WorkBook = `MIME-Version: 1.0
X-Document-Type: Workbook
Content-Type: multipart/related; boundary="----=_NextPart_dummy"

------=_NextPart_dummy
Content-Location: WorkBook.htm
Content-Type: text/html; charset=windows-1252

` + html_start + `
<head>
<meta name="Excel Workbook Frameset">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<link rel="File-List" href="filelist.xml">
<!--[if gte mso 9]><xml>
         <x:ExcelWorkbook>
            <x:ExcelWorksheets>{ExcelWorksheets}</x:ExcelWorksheets>
            <x:ActiveSheet>0</x:ActiveSheet>
         </x:ExcelWorkbook>
</xml><![endif]-->
</head>
<frameset>
            <frame src="sheet0.htm" name="frSheet">
            <noframes><body><p>This page uses frames, but your browser does not support them.</p></body></noframes>
</frameset>
</html>
{HTMLWorksheets}
Content-Location: filelist.xml
Content-Type: text/xml; charset="utf-8"

<xml xmlns:o="urn:schemas-microsoft-com:office:office">
            <o:MainFile HRef="../WorkBook.htm"/>
            {ListWorksheets}
            <o:File HRef="filelist.xml"/>
</xml>
------=_NextPart_dummy--
`
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (tables, filename) {
        var context_WorkBook = {
            ExcelWorksheets: ''
            , HTMLWorksheets: ''
            , ListWorksheets: ''
        };
        var tables = jQuery(tables);
        $.each(tables, function (SheetIndex) {
            var $table = $(this);
            var SheetName = $table.attr('data-SheetName');
            if ($.trim(SheetName) === '') {
                SheetName = 'Sheet' + SheetIndex;
                SheetName = $(this).id;
            }
            context_WorkBook.ExcelWorksheets += format(template_ExcelWorksheet, {
                SheetIndex: SheetIndex
                , SheetName: SheetName
            });
            context_WorkBook.HTMLWorksheets += format(template_HTMLWorksheet, {
                SheetIndex: SheetIndex
                , SheetContent: $table.html()
            });
            context_WorkBook.ListWorksheets += format(template_ListWorksheet, {
                SheetIndex: SheetIndex
            });
        });

        var link = document.createElement("A");
        link.href = uri + base64(format(template_WorkBook, context_WorkBook));
        link.download = filename || 'Workbook.xls';
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
})(jQuery);