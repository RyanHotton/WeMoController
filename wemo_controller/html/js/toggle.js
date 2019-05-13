// var $ = require('jquery')
// var vue = require('vue')

$(document).ready(function() {
    // copyright year
    var curDate = new Date()
    $('span.copyright-year').html(curDate.getFullYear())

    // initialize tabs
    $('.tabs').tabs();

    // event listener for toggle button being clicked
    $('button.btn-toggle-wemo').on('click', function (e) {
        // prevent default action
        e.preventDefault()
        // declare button variable for ease of use
        var toggleBtn = $(this)
        // disable button
        toggleBtn.prop('disabled', true)
        // change button name and colour
        // ON: #43a047 green darken-1
        // OFF: #b71c1c red darken-4
        toggleBtn.toggleClass('#43a047 green darken-1')
        toggleBtn.toggleClass('#b71c1c red darken-4')
        if (toggleBtn.hasClass('#43a047 green darken-1') ) {
            toggleBtn.html('On')
        } else {
            toggleBtn.html('Off')
        }
        // enable button
        toggleBtn.prop('disabled', false)
    }) 

    // show container
    $('div#main-container').removeClass('rdhidden')
})