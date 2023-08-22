function highlightCode(code, language)
{
	let result = hljs.highlight(code, { language, ignoreIllegals: true })
	return result.value
}

var bodyElement = document.getElementsByTagName('body')[0]
var hammer = new Hammer(bodyElement);

function addGestureEventListener(dotNetObjectRef) {
	hammer.on("swipeleft swiperight", function (ev) {
		dotNetObjectRef.invokeMethodAsync('OnGesture', ev.type)
	});
}

function removeGestureEventListener(dotNetObjectRef) {
	hammer.off("swipeleft swiperight");
}

function changeUrl(subPage) {
	window.history.pushState("object or string", "Title", subPage);
}
