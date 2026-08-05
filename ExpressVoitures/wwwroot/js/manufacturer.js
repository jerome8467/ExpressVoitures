let selectedManufacturerId = null;
let selectedVehicleModelId = null;
let manufacturerToDeleteId = null;
let vehicleModelToDeleteId = null;
let finitionToDeleteId = null;
let itemToDeleteId = null;
let confirmDeleteCallback = null;
let itemToEditId = null;
let confirmEditCallback = null;

async function selectManufacturer(id, element) {
    selectedManufacturerId = id;
    selectedManufacturerName = element.querySelector('p').textContent;
    selectedVehicleModelId = null;

    document.querySelectorAll('#manufacturerList .ev-CardLeft').forEach(el => el.classList.remove('selected'));
    element.classList.add('selected');

    document.getElementById('vehicleModelColonne').classList.remove('disabled');
    document.getElementById('separateurVehicleModelColonne').classList.remove('disabled');
    document.getElementById('separateurFinitionColonne').classList.add('disabled');
    document.getElementById('finitionColonne').classList.add('disabled');

    // Charger les vehicleModels via AJAX
    const response = await fetch(`/Manufacturer/GetVehicleModels?manufacturerId=${id}`);
    if (response.ok) {
        const vehicleModels = await response.json();
        const listContainer = document.getElementById('vehicleModelList');
        listContainer.innerHTML = '';
        vehicleModels.forEach(vm => {
            listContainer.insertAdjacentHTML('beforeend', `
                <div class="ev-cartManufacturer">
                    <div class="ev-CardLeft" data-id="${vm.id}" onclick="selectVehicleModel(${vm.id}, this)">
                        <p>${vm.name}</p>
                    </div>
                    <div style="display:flex;">
                        <div class="ev-CardRight" onclick="openEditModal(${vm.id}, '${vm.name}', updateVehicleModel, 'Modifier le modèle')">
                        <i class="bi-pencil"></i></div>
                        <div class="ev-CardRight" onclick="openDeleteModal(${vm.id}, deleteVehicleModel, 'Voulez-vous vraiment supprimer ce modèle ?')">
                        <i class="bi-trash"></i></div>
                    </div>
                </div>
            `);
        });

        // Vider la liste des finitions
        document.getElementById('finitionList').innerHTML = '';
    }
}

async function selectVehicleModel(id, element) {
    selectedVehicleModelId = id;
    selectedVehicleModelName = element.querySelector('p').textContent;

    element.classList.add('selected');

    document.getElementById('separateurFinitionColonne').classList.remove('disabled');
    document.getElementById('finitionColonne').classList.remove('disabled');

    const response = await fetch(`/Manufacturer/GetFinitions?vehicleModelId=${id}`);
    if (response.ok) {
        const finitions = await response.json();
        const listContainer = document.getElementById('finitionList');
        listContainer.innerHTML = '';
        finitions.forEach(f => {
            const cardLeft = fromAddCar
                ? `<div class="ev-CardLeft" onclick="selectFinition(${f.id}, '${f.name}')"><p>${f.name}</p></div>`
                : `<div class="ev-CardLeft"><p>${f.name}</p></div>`;
            listContainer.insertAdjacentHTML('beforeend', `
                <div class="ev-cartManufacturer" data-finitionid="${f.id}">
                    ${cardLeft}
                    <div style="display:flex;">
                        <div class="ev-CardRight" onclick="openEditModal(${f.id}, '${f.name}', updateFinition, 'Modifier la finition')">
                        <i class="bi-pencil"></i></div>
                        <div class="ev-CardRight" onclick="openDeleteModal(${f.id}, deleteFinition, 'Voulez-vous vraiment supprimer cette finition ?')">
                        <i class="bi-trash"></i></div>
                    </div>
                </div>
            `);
        });
    }
}


async function addManufacturer() {
    const name = document.getElementById('manufacturerName').value;
    const response = await fetch('/Manufacturer/AddManufacturer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Name: name })
    });
    if (response.ok) {
        document.getElementById('manufacturerError').style.display = 'none';
        const newManufacturer = await response.json();
        const listContainer = document.getElementById('manufacturerList');
        listContainer.insertAdjacentHTML('beforeend', `
            <div class="ev-cartManufacturer">
                <div class="ev-CardLeft" data-id="${newManufacturer.id}" onclick="selectManufacturer(${newManufacturer.id}, this)">
                    <p>${newManufacturer.name}</p>
                </div>
                <div style="display:flex;">
                    <div class="ev-CardRight" onclick="openEditModal(${newManufacturer.id}, '${newManufacturer.name}', updateManufacturer, 'Modifier le constructeur')">
                    <i class="bi-pencil"></i></div>
                    <div class="ev-CardRight" onclick="openDeleteModal(${newManufacturer.id}, deleteManufacturer, 'Voulez-vous vraiment supprimer ce constructeur ?')">
                    <i class="bi-trash"></i></div>
                </div>
            </div>`);
        document.getElementById('manufacturerName').value = '';
        const newElement = listContainer.querySelector(`[data-id="${newManufacturer.id}"]`);
        if (newElement) selectManufacturer(newManufacturer.id, newElement);
    } else {
        const errors = await response.json();
        document.getElementById('manufacturerError').style.display = 'block';
        document.getElementById('manufacturerError').textContent = errors[0];
    }
}

async function addVehicleModel() {
    const name = document.getElementById('vehiclemodelName').value;
    const response = await fetch('/Manufacturer/AddVehicleModel', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Name: name, ManufacturerId: selectedManufacturerId })
    });
    if (response.ok) {
        document.getElementById('vehicleModelError').style.display = 'none';
        const newVehicleModel = await response.json();
        const listContainer = document.getElementById('vehicleModelList');
        listContainer.insertAdjacentHTML('beforeend', `
            <div class="ev-cartManufacturer">
                <div class="ev-CardLeft" data-id="${newVehicleModel.id}" onclick="selectVehicleModel(${newVehicleModel.id}, this)">
                    <p>${newVehicleModel.name}</p>
                </div>
                <div style="display:flex;">
                    <div class="ev-CardRight" onclick="openEditModal(${newVehicleModel.id}, '${newVehicleModel.name}', updateVehicleModel, 'Modifier le modèle')">
                    <i class="bi-pencil"></i></div>
                    <div class="ev-CardRight" onclick="openDeleteModal(${newVehicleModel.id}, deleteVehicleModel, 'Voulez-vous vraiment supprimer ce modèle ?')">
                    <i class="bi-trash"></i></div>
                </div>
            </div>`);
        document.getElementById('vehiclemodelName').value = '';
        const newElement = listContainer.querySelector(`[data-id="${newVehicleModel.id}"]`);
        if (newElement) selectVehicleModel(newVehicleModel.id, newElement);
    } else {
        const errors = await response.json();
        document.getElementById('vehicleModelError').style.display = 'block';
        document.getElementById('vehicleModelError').textContent = errors[0];
    }
}

async function addFinition() {
    const name = document.getElementById('finitionName').value;
    const response = await fetch('/Manufacturer/AddFinition', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Name: name, VehicleModelId: selectedVehicleModelId })
    });
    if (response.ok) {
        document.getElementById('finitionError').style.display = 'none';
        const newFinition = await response.json();
        const listContainer = document.getElementById('finitionList');
        const cardLeft = fromAddCar
            ? `<div class="ev-CardLeft" onclick="selectFinition(${newFinition.id}, '${newFinition.name}')"><p>${newFinition.name}</p></div>`
            : `<div class="ev-CardLeft"><p>${newFinition.name}</p></div>`;
        listContainer.insertAdjacentHTML('beforeend', `
            <div class="ev-cartManufacturer" data-finitionid="${newFinition.id}">
                ${cardLeft}
                <div style="display:flex;">
                    <div class="ev-CardRight" onclick="openEditModal(${newFinition.id}, '${newFinition.name}', updateFinition, 'Modifier la finition')">
                    <i class="bi-pencil"></i></div>
                    <div class="ev-CardRight" onclick="openDeleteModal(${newFinition.id}, deleteFinition, 'Voulez-vous vraiment supprimer cette finition ?')">
                    <i class="bi-trash"></i></div>
                </div>
            </div>`);
        document.getElementById('finitionName').value = '';
    } else {
        const errors = await response.json();
        document.getElementById('finitionError').style.display = 'block';
        document.getElementById('finitionError').textContent = errors[0];
    }
}






function openDeleteModal(id, callback, message) {
    itemToDeleteId = id;
    confirmDeleteCallback = callback;
    document.getElementById('deleteModalMessage').textContent = message;
    document.getElementById('deleteModal').style.display = 'flex';
}

function closeDeleteModal() {
    document.getElementById('deleteModal').style.display = 'none';
    itemToDeleteId = null;
    confirmDeleteCallback = null;
}

async function confirmDelete() {
    if (confirmDeleteCallback) await confirmDeleteCallback(itemToDeleteId);
    closeDeleteModal();
}

async function deleteManufacturer(id) {
    const response = await fetch(`/Manufacturer/DeleteManufacturer?id=${id}`, { method: 'POST' });
    if (response.ok) {
        document.querySelector(`[data-id="${id}"]`).closest('.ev-cartManufacturer').remove();
        document.getElementById('separateurVehicleModelColonne').classList.add('disabled');
        document.getElementById('vehicleModelColonne').classList.add('disabled');
        document.getElementById('separateurFinitionColonne').classList.add('disabled');
        document.getElementById('finitionColonne').classList.add('disabled');
        document.querySelectorAll('#manufacturerList .ev-CardLeft').forEach(el => el.classList.remove('selected'));
        document.getElementById('vehicleModelList').innerHTML = '';
        document.getElementById('finitionList').innerHTML = '';
        selectedManufacturerId = null;
    }
}

async function deleteVehicleModel(id) {
    const response = await fetch(`/Manufacturer/DeleteVehicleModel?id=${id}`, { method: 'POST' });
    if (response.ok) {
        document.querySelector(`[data-id="${id}"]`).closest('.ev-cartManufacturer').remove();
        document.getElementById('separateurFinitionColonne').classList.add('disabled');
        document.getElementById('finitionColonne').classList.add('disabled');
        document.querySelectorAll('#vehicleModelList .ev-CardLeft').forEach(el => el.classList.remove('selected'));
        document.getElementById('finitionList').innerHTML = '';
        selectedVehicleModelId = null;
    }
}

async function deleteFinition(id) {
    const response = await fetch(`/Manufacturer/DeleteFinition?id=${id}`, { method: 'POST' });
    if (response.ok) {
        document.querySelector(`[data-finitionid="${id}"]`).closest('.ev-cartManufacturer').remove();
        document.querySelectorAll('#finitionList .ev-CardLeft').forEach(el => el.classList.remove('selected'));
    }
}







function openEditModal(id, name, callback, title) {
    itemToEditId = id;
    confirmEditCallback = callback;
    document.getElementById('editModalTitle').textContent = title;
    document.getElementById('editModalInput').value = name;
    document.getElementById('editModal').style.display = 'flex';
}

function closeEditModal() {
    document.getElementById('editModal').style.display = 'none';
    document.getElementById('editModalError').style.display = 'none';
    itemToEditId = null;
    confirmEditCallback = null;
}

async function confirmEdit() {
    if (confirmEditCallback) {
        const success = await confirmEditCallback(itemToEditId);
        if (success) closeEditModal();
    }
}

async function updateManufacturer(id) {
    const name = document.getElementById('editModalInput').value;
    const response = await fetch(`/Manufacturer/UpdateManufacturer`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Id: id, Name: name })
    });
    if (response.ok) {
        document.querySelector(`[data-id="${id}"] p`).textContent = name;
        return true;
    } else {
        const errors = await response.json();
        document.getElementById('editModalError').style.display = 'block';
        document.getElementById('editModalError').textContent = errors[0];
        return false;
    }
}

async function updateVehicleModel(id) {
    const name = document.getElementById('editModalInput').value;
    const response = await fetch(`/Manufacturer/UpdateVehicleModel`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Id: id, Name: name, ManufacturerId: selectedManufacturerId })
    });
    if (response.ok) {
        document.querySelector(`[data-id="${id}"] p`).textContent = name;
        return true;
    } else {
        const errors = await response.json();
        document.getElementById('editModalError').style.display = 'block';
        document.getElementById('editModalError').textContent = errors[0];
        return false;
    }
}

async function updateFinition(id) {
    const name = document.getElementById('editModalInput').value;
    const response = await fetch(`/Manufacturer/UpdateFinition`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Id: id, Name: name, VehicleModelId: selectedVehicleModelId })
    });
    if (response.ok) {
        document.querySelector(`[data-finitionid="${id}"] p`).textContent = name;
        return true;
    } else {
        const errors = await response.json();
        document.getElementById('editModalError').style.display = 'block';
        document.getElementById('editModalError').textContent = errors[0];
        return false;
    }
}

let selectedManufacturerName = '';
let selectedVehicleModelName = '';

function selectFinition(id, name) {
    window.location = `/CarAdmin/AddCarAdminIndex?manufacturerId=${selectedManufacturerId}&manufacturerName=${encodeURIComponent(selectedManufacturerName)}&vehicleModelId=${selectedVehicleModelId}&vehicleModelName=${encodeURIComponent(selectedVehicleModelName)}&finitionId=${id}&finitionName=${encodeURIComponent(name)}`;
}