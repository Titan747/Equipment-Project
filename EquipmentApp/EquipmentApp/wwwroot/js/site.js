// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.



const uri = 'https://localhost:44324/api/equipment';
let equipmentlist = [];





function getEquipments() {
    fetch(uri, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
    })
        .then(response => response.json())
        .then(data => _displayequipmentList(data))
        .catch(error => console.error('Unable to get items.', error));
}



function addEquipment() {
    debugger;
    const Equipment = {
        equipmentName: document.getElementById('equipmentName').value,
        equipmentAmount: parseInt(document.getElementById('equipmentAmount').value),
        equipmentPurchaseDate: document.getElementById('equipmentPurchaseDate').value
    };
    //Fetch API
    //axios
    //jquery ajax
    //angular http service
    fetch(uri, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(Equipment)
    })
        .then(response => response.json())
        .then(() => {
            getEquipments();
            ///addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}



function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}



function displayEditForm(id) {
    debugger;
    const item = equipmentlist.find(item => item.equipmentId === id);



    document.getElementById('editEquipmentId').value = item.equipmentId;
    document.getElementById('editEquipmentName').value = item.equipmentName;
    document.getElementById('editEquipmentAmount').value = item.equipmentAmount;
    document.getElementById('editEquipmentPurchaseDate').value = item.equipmentPurchaseDate;
    document.getElementById('editForm').style.display = 'block';
}



function updateItem() {
    const equipmentId = document.getElementById('editEquipmentId').value;
    const Equipment = {
        equipmentName: document.getElementById('editEquipmentName').value,
        equipmentAmount: parseInt(document.getElementById('editEquipmentAmount').value),
        equipmentPurchaseDate: document.getElementById('editEquipmentPurchaseDate').value
    };



    fetch(`${uri}/${equipmentId}`, {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(Equipment)
    })
        .then(() => getEquipments())
        .catch(error => console.error('Unable to update item.', error));



    closeInput();



    return false;
}



function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}



function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';



    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}



function _displayequipmentList(data) {
    debugger;
    const tBody = document.getElementById('equipmentlist');
    tBody.innerHTML = '';



    _displayCount(data.length);



    const button = document.createElement('button');



    data.forEach(item => {
        let lableforId = document.createElement('label');
        lableforId.innerHTML = item.equipmentId;



        let lableforequipmentName = document.createElement('label');
        lableforequipmentName.innerHTML = item.equipmentName;



        let lableforequipmentAmount = document.createElement('label');
        lableforequipmentAmount.innerHTML = item.equipmentAmount;



        let lableforequipmentPurchaseDate = document.createElement('label');
        lableforequipmentPurchaseDate.innerHTML = item.equipmentPurchaseDate;



        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.equipmentId})`);



        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.equipmentId})`);



        let tr = tBody.insertRow();



        let td1 = tr.insertCell(0);
        td1.appendChild(lableforId);

        let td2 = tr.insertCell(1);
        td2.appendChild(lableforequipmentName);



        let td3 = tr.insertCell(2);
        td3.appendChild(lableforequipmentAmount);



        let td4 = tr.insertCell(3);
        td4.appendChild(lableforequipmentPurchaseDate);



        //let td2 = tr.insertCell(1);
        //let textNode = document.createTextNode(item.name);
        //td2.appendChild(textNode);



        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);



        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });



    equipmentlist = data;
}