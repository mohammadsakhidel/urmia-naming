var speed = 150;
////////////////////////////////////////////////////// HANDLERS:
$(function () {

    $('.menu-container > a').click(function () {

        if (!$(this).hasClass('mi-selected')) {
            $('.submenu').slideUp(speed);
            $(this).next('div').slideDown(speed);
            $('.mi-selected').removeClass('mi-selected').addClass('mi');
            $(this).removeClass('mi').addClass('mi-selected');
        }
        else {

            $(this).next('div').slideUp(250);
            $(this).removeClass('mi-selected').addClass('mi');

        }

    });

});
////////////////////////////////////////////////////// FUNCTIONS: