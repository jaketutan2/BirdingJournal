// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var birds = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('BirdCommonName'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Home/SearchBird?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#search-box').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    }, {
        name: 'birds',
        display: 'BirdCommonName',
        source: birds
    });
});


