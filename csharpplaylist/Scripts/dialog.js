const display = document.getElementById('overlay');
const popup = document.getElementById('dialog');

function fDialog(type) {
	const title = document.getElementById('dialogtitle');
	const content = document.getElementById('dialogcontent');
	const footer = document.getElementById('dialogfooter');
	const contentInput = document.getElementById('dialog_' + type).innerHTML;
	display.style.display = 'block';
	popup.style.top = 'Calc(40vh - 125px)';
	title.innerHTML = type.charAt(0).toUpperCase() + type.slice(1);
	content.innerHTML = contentInput;
	footer.innerHTML = '&copy; 2020 - Timo van Rooijen';
}

function fCloseDialog() {
	display.style.display = 'none';
	popup.style.top = '-250px';
}