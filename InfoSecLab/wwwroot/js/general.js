let blazorLoaded = false;

function loadBlazor()
{
    blazorLoaded = true;
}

function getHeightInPx(elem)
{
    return document.getElementById(elem).offsetHeight + "px"
}

function setHeightInPx(elem, height)
{
    document.getElementById(elem).style.height = height;
}