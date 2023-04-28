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
