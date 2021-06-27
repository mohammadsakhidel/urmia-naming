///////////////////////////////////////////// Functions:
function Open(pageURL, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2) - 50;
    var targetWin = window.open(pageURL, title, 'width=' + w + ', height=' + h + ', left=' + left + ', top=' + top + ', resizable=yes, scrollbars=yes');
    return false;
}

function OpenFull(pageURL) {
    var targetWin = window.open(pageURL, '', 'width=' + screen.width + ', height=' + screen.height + ', resizable=yes, scrollbars=yes, fullscreen=yes');
    targetWin.moveTo(0, 0);
    targetWin.resizeTo(screen.width,screen.height);
    return false;
}

function showSubmenu(miClass)
{
    $('.' + miClass).next('div').show();
    $('.' + miClass).removeClass('mi').addClass('mi-selected');
}