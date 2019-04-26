$('button.btn-toggle-wemo').on('click', function () {
    var toggleBtn = $(this)
    toggleBtn.toggleClass('btn-success')
    toggleBtn.toggleClass('btn-danger')
    if ( toggleBtn.hasClass('btn-success') ) {
        toggleBtn.html('On')
    } else {
        toggleBtn.html('Off')
    }
    
})
