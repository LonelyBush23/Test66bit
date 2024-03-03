var connection = new signalR.HubConnectionBuilder().withUrl("/hub66").build();

connection.on("ReceivedProducts", (products) => {
	var body = document.getElementById("tableBody");
	$("#tableBody").empty();
	for (let i = 0; i < products.length; i++) {
		var tr = document.createElement("tr");
		for (key in products[i]) {
			if (key != `id`) {
				var td = document.createElement("td");
				td.appendChild(document.createTextNode(`${products[i][key]}`));
				tr.appendChild(td);
			}
		}
		var td = document.createElement("td");
		var ed = document.createElement("a");
		ed.setAttribute('href', `../Catalog/Edit?id=${products[i].id}`);
		ed.textContent = `Edit`;
		var ed1 = document.createElement("a");
		ed1.setAttribute('href', `../Catalog/Delete?id=${products[i].id}`);
		ed1.textContent = `Delete`;
		td.appendChild(ed);
		td.appendChild(document.createTextNode(` | `));
		td.appendChild(ed1);
		tr.appendChild(td);

		body.appendChild(tr);
	}
});

function send() {
	connection.send("Send");
}

function y() {
	console.log("Cool!")
	send();
}

function n() {

}

connection.start().then(y, n)