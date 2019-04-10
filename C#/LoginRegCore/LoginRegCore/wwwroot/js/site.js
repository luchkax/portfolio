// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    var notes = [];
    $.get("/asnotes", function(data, status){
        if(data != null) notes = data;
    });

    $('a#title_list').click(function(e){
        var noteid = $(this).attr('data-target'), note;
        $.map(notes, function (val, i) {
            if(val.noteID == noteid) note = val.content
        })
        $('#content_input').attr('type', 'hidden')
        $('#save_title').attr('type', 'hidden')
        $('.note_content').text(note)
    })

    $('a#title_edit').click(function (e) {
        var noteid = $(this).attr('data-target'), note;
        var _title;
        $.map(notes, function (val, i) {
            if(val.noteID == noteid) note = val.content
        })
        $.map($('a#title_list'), function ($val, i) {
            if($val.dataset.target == noteid) _title = $val;
        })
        $('.note_content').text('')
        $('#content_input').attr('type', 'text')
        $('#content_input').attr('data-target', noteid)
        $('#save_title').attr('type', 'button')
        $('#content_input').attr('data-maincategorie', _title.text)
        $('#content_input').attr('value', note)
    })

    $('input#save_title').click(function (e) {
        var noteid = $('input#content_input').attr('data-target');
        var _title = $('input#content_input').attr('data-maincategorie');
        var _content = $('input#content_input').val();
        $.post("/edit", { id: noteid, title: _title, content: _content }, function(data, status){
           return status;
        });
        location.reload()
    })

});