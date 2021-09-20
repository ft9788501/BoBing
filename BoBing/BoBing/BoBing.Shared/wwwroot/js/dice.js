function dice(diceArr) {
	var container = document.getElementById('dicebox');
	$('.redpacket').remove();
	for (var i = 0; i < diceArr.length; i++) {
		container.appendChild(this.createDice(diceArr[i] + 1, i));
	}
}
function createDice(num, i) {
	var image = document.createElement('img');
	image.setAttribute("class", "redpacket");
	image.id = "redpacket" + i;
    image.src = '_content/BoBing.Shared/images/dice' + num + '.jpg';
	return image;
}
