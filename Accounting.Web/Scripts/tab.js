
function testit(st, label, url) {

    var maintab = jQuery('#tabs', '#RightPane').tabs({
        add: function (e, ui) {

            // append close thingy
            $(ui.tab).parents('li:first')
        .append('<span class="ui-tabs-close ui-icon ui-icon-close" title="Close Tab"></span>')
        .find('span.ui-tabs-close')
        .click(function () {
            maintab.tabs('remove', $('li', maintab).index($(this).parents('li:first')[0]));
        });
            // select just added tab
            maintab.tabs('select', '#' + ui.panel.id);
        }
    });
    maintab.tabs('add', st, label);

    //$(st,"#tabs").load(treedata.url);
    $.ajax({
        url: url,
        type: "GET",
        dataType: "html",
        complete: function (req, err) {
            $(st, "#tabs").append('<iframe src="' + url + '" style="width:98%; height:600px;" scrolling="auto" marginwidth="0" marginheight="0" frameborder="0" vspace="10" hspace="0" />');
        }
    });

}
function VoucherLinkClicked(a) {
    var maintab = jQuery('#tabs', '#RightPane').tabs();
    //alert($(a).attr("href"));
    var url = $(a).attr("href");

    var st = "#t" + $(a).attr("title");

    if ($(st).html() != null) {
        maintab.tabs('select', st);
    } else {

        maintab.tabs('add', st, $(a).attr("title"));

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            complete: function (req, err) {
                $(st, "#tabs").append('<iframe src="' + url + '" style="width:100%;min-height:700px;" scrolling="auto" marginwidth="0" marginheight="0" frameborder="0" vspace="10" hspace="0" />');

            }
        });

    }
    return false;
}
function EmployeeLinkClicked(a) {
    var maintab = jQuery('#tabs', '#RightPane').tabs();
    //alert($(a).attr("href"));
    var url = $(a).attr("href");

    var st = "#t" + $(a).text();

    if ($(st).html() != null) {
        maintab.tabs('select', st);
    } else {

        maintab.tabs('add', st, $(a).text());

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            complete: function (req, err) {
                $(st, "#tabs").append('<iframe src="' + url + '" style="width:100%; height:1400px;min-height:700px;" scrolling="auto" marginwidth="0" marginheight="0" frameborder="0" vspace="10" hspace="0" />');

            }
        });

    }
    return false;
}
function EmployeeLinkClickedT(a) {
    var maintab = jQuery('#tabs', '#RightPane').tabs();
    //alert($(a).attr("href"));
    var url = $(a).attr("href");

    var st = "#t" + $(a).attr("title");

    if ($(st).html() != null) {
        maintab.tabs('select', st);
    } else {

        maintab.tabs('add', st, $(a).attr("title"));

        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            complete: function (req, err) {
                $(st, "#tabs").append('<iframe src="' + url + '" style="width:100%;min-height:700px;" scrolling="auto" marginwidth="0" marginheight="0" frameborder="0" vspace="10" hspace="0" />');

            }
        });

    }
    return false;
}
jQuery(document).ready(function () {

    var maintab = jQuery('#tabs', '#RightPane').tabs({
        add: function (e, ui) {

            // append close thingy
            $(ui.tab).parents('li:first')
        .append('<span class="ui-tabs-close ui-icon ui-icon-close" title="Close Tab"></span>')
        .find('span.ui-tabs-close')
        .click(function () {
            maintab.tabs('remove', $('li', maintab).index($(this).parents('li:first')[0]));
        });
            // select just added tab
            maintab.tabs('select', '#' + ui.panel.id);
        }
    });
    $("a.tablink").click(function () {

        var url = $(this).attr("href");

        var st = "#t" + $(this).attr("id");

        if ($(st).html() != null) {
            maintab.tabs('select', st);
        } else {

            maintab.tabs('add', st, $(this).text());

            $.ajax({
                url: url,
                type: "GET",
                dataType: "html",
                complete: function (req, err) {
                    $(st, "#tabs").append('<iframe src="' + url + '" style="width:100%; height:auto;min-height:600px;" scrolling="auto" marginwidth="0" marginheight="0" frameborder="0" vspace="10" hspace="0" />');

                }
            });

        }
        return false;
    });


});
