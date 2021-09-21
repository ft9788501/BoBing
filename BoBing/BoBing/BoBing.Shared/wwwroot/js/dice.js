function dice(diceArr, animation) {
    var container = document.getElementById('dicebox');
    $('.redpacket').remove();
    $('.redpacketNoAnimation').remove();
	for (var i = 0; i < diceArr.length; i++) {
        container.appendChild(this.createDice(diceArr[i] + 1, i, animation));
	}
}
function createDice(num, i,animation) {
	var image = document.createElement('img');
    image.setAttribute("class", animation ? "redpacket" :"redpacketNoAnimation");
    image.id = (animation ? "redpacket" : "redpacketNoAnimation") + i;
    image.src = '_content/BoBing.Shared/images/dice' + num + '.jpg';
	return image;
}
