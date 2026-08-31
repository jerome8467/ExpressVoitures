Dropzone.autoDiscover = false;

flatpickr.localize(flatpickr.l10ns.fr);

document.addEventListener('DOMContentLoaded', () => {

    switchOnglet('info');

    const container = document.querySelector('.ev-bodyAddCarAdminIndex');

    let dateAcquisitionPicker = flatpickr("#dateAcquisition", {
        dateFormat: "d/m/Y",
        locale: "fr",
        allowInput: false,
        monthSelectorType: 'static',
        onChange: function (selectedDates) {
            document.getElementById('hiddenPurchaseDate').value = selectedDates[0] ? selectedDates[0].toISOString().split('T')[0] : '';
        }
    });

    let dateMiseEnLignePicker = flatpickr("#dateMiseEnLigne", {
        dateFormat: "d/m/Y",
        locale: "fr",
        allowInput: false,
        monthSelectorType: 'static',
        onChange: function (selectedDates) {
            document.getElementById('hiddenAvailabilityDate').value = selectedDates[0] ? selectedDates[0].toISOString().split('T')[0] : '';
        }
    });

    let dateVentePicker = flatpickr("#dateVente", {
        dateFormat: "d/m/Y",
        locale: "fr",
        allowInput: false,
        monthSelectorType: 'static',
        onChange: function (selectedDates) {
            document.getElementById('hiddenSaleDate').value = selectedDates[0] ? selectedDates[0].toISOString().split('T')[0] : '';
        }
    });

    window.clearDateAcquisition = function () {
        dateAcquisitionPicker.clear();
        document.getElementById('hiddenPurchaseDate').value = '';
    };

    window.clearDateMiseEnLigne = function () {
        dateMiseEnLignePicker.clear();
        document.getElementById('hiddenAvailabilityDate').value = '';
    };

    window.clearDateVente = function () {
        dateVentePicker.clear();
        document.getElementById('hiddenSaleDate').value = '';
    };

    new TomSelect('#visuelYear', {
        maxOptions: null,
        controlInput: null
    });

    document.getElementById('visuelKilometer').value = container.dataset.kilometer ?? '';
    document.getElementById('visuelDescription').value = container.dataset.description ?? '';
    document.getElementById('visuelRepairPrice').value = container.dataset.repairprice ?? '';
    document.getElementById('visuelTypeOfRepair').value = container.dataset.typeofrepair ?? '';
    document.getElementById('visuelPurchasePrice').value = container.dataset.purchaseprice ?? '';
    document.getElementById('visuelAdditionalAmount').value = container.dataset.additionalamount ?? '';

    if (container.dataset.purchasedate) dateAcquisitionPicker.setDate(container.dataset.purchasedate, false, "Y-m-d");
    if (container.dataset.availabilitydate) dateMiseEnLignePicker.setDate(container.dataset.availabilitydate, false, "Y-m-d");
    if (container.dataset.saledate) dateVentePicker.setDate(container.dataset.saledate, false, "Y-m-d");

    const tomYear = document.getElementById('visuelYear').tomselect;
    if (tomYear) tomYear.setValue(container.dataset.year);

    const status = parseInt(container.dataset.status);
    const statusBtns = document.querySelectorAll('.ev-btn-statut');
    statusBtns.forEach(el => el.classList.remove('selected'));
    statusBtns[status].classList.add('selected');
    document.getElementById('hiddenStatus').value = status;

    const params = new URLSearchParams(window.location.search);
    if (params.get('manufacturerId')) {
        document.getElementById('hiddenManufacturerId').value = params.get('manufacturerId');
        document.getElementById('hiddenManufacturerName').value = params.get('manufacturerName');
        document.getElementById('selectedManufacturerName').textContent = params.get('manufacturerName');
        document.getElementById('selectedManufacturerName').classList.remove('empty');
        document.getElementById('hiddenVehicleModelId').value = params.get('vehicleModelId');
        document.getElementById('hiddenVehicleModelName').value = params.get('vehicleModelName');
        document.getElementById('selectedVehicleModelName').textContent = params.get('vehicleModelName');
        document.getElementById('selectedVehicleModelName').classList.remove('empty');
        document.getElementById('hiddenFinitionId').value = params.get('finitionId');
        document.getElementById('hiddenFinitionName').value = params.get('finitionName');
        document.getElementById('selectedFinitionName').textContent = params.get('finitionName');
        document.getElementById('selectedFinitionName').classList.remove('empty');
    }

    const form = document.getElementById('editCarForm');
    if (form) {
        form.addEventListener('submit', function () {
            document.getElementById('hiddenKilometer').value = document.getElementById('visuelKilometer').value;
            document.getElementById('hiddenYear').value = document.getElementById('visuelYear').value;
            document.getElementById('hiddenDescription').value = document.getElementById('visuelDescription').value;
            document.getElementById('hiddenRepairPrice').value = document.getElementById('visuelRepairPrice').value;
            document.getElementById('hiddenTypeOfRepair').value = document.getElementById('visuelTypeOfRepair').value;
            document.getElementById('hiddenPurchasePrice').value = document.getElementById('visuelPurchasePrice').value;
            document.getElementById('hiddenAdditionalAmount').value = document.getElementById('visuelAdditionalAmount').value;
        });
    }

    new Dropzone("#imageDropzone", {
        url: "/CarAdmin/AddImage",
        acceptedFiles: "image/*",
        addRemoveLinks: false,
        autoProcessQueue: false,
        thumbnailWidth: 120,
        thumbnailHeight: 120,
        previewsContainer: false,
        init: function () {
            this.on("addedfile", function (file) {
                const formData = new FormData();
                formData.append('image', file);
                formData.append('carId', document.querySelector('input[name="CarId"]').value);
                formData.append('__RequestVerificationToken', document.querySelector('input[name="__RequestVerificationToken"]').value);

                fetch('/CarAdmin/AddImage', {
                    method: 'POST',
                    body: formData
                }).then(response => response.json())
                    .then(data => {
                        file._imageId = data.imageId;
                    });
            });

            this.on("thumbnail", function (file, dataUrl) {
                const preview = document.createElement('div');
                preview.className = 'ev-imagePreview';
                preview.innerHTML = `
                    <img src="${dataUrl}" />
                    <div class="ev-imagePreviewActions">
                        <button type="button" class="btn-cover"><i class="bi-star"></i></button>
                        <button type="button" class="btn-remove"><i class="bi-trash"></i></button>
                    </div>
                `;
                document.getElementById('imagePreviewList').appendChild(preview);
                if (document.querySelectorAll('.ev-imagePreview').length === 1) {
                    setCover(preview);
                }
                preview.querySelector('.btn-cover').addEventListener('click', () => setCoverExisting(preview.querySelector('.btn-cover'), file._imageId));
                preview.querySelector('.btn-remove').addEventListener('click', () => deleteExistingImage(file._imageId, preview.querySelector('.btn-remove')));
            });
        }
    });

});

function switchOnglet(tab) {
    document.getElementById('sectionInfo').style.display = tab === 'info' ? 'flex' : 'none';
    document.getElementById('sectionImages').style.display = tab === 'images' ? 'flex' : 'none';
    document.getElementById('ongletInfo').classList.toggle('selected', tab === 'info');
    document.getElementById('ongletImages').classList.toggle('selected', tab === 'images');
}

function selectStatus(value, element) {
    document.querySelectorAll('.ev-btn-statut').forEach(el => el.classList.remove('selected'));
    element.classList.add('selected');
    document.getElementById('hiddenStatus').value = value;
}

function setCover(preview) {
    document.querySelectorAll('.ev-imagePreview').forEach(el => {
        el.classList.remove('cover');
        el.querySelector('.btn-cover i').className = 'bi-star';
    });
    preview.classList.add('cover');
    preview.querySelector('.btn-cover i').className = 'bi-star-fill';
}

function setCoverExisting(btn, imageId) {
    const formData = new FormData();
    formData.append('imageId', imageId);
    formData.append('carId', document.querySelector('[name="CarId"]').value);
    formData.append('__RequestVerificationToken', document.querySelector('input[name="__RequestVerificationToken"]').value);

    fetch('/CarAdmin/SetCover', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (response.ok) {
            document.querySelectorAll('.ev-imagePreview').forEach(el => {
                el.classList.remove('cover');
                el.querySelector('.btn-cover i').className = 'bi-star';
            });
            btn.closest('.ev-imagePreview').classList.add('cover');
            btn.querySelector('i').className = 'bi-star-fill';
        }
    });
}

function deleteExistingImage(imageId, btn) {
    const carId = document.querySelector('[name="CarId"]').value;
    fetch(`/CarAdmin/DeleteImage?imageId=${imageId}&carId=${carId}`, {
        method: 'POST',
        headers: { 'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value }
    }).then(response => {
        if (response.ok) {
            const preview = btn.closest('.ev-imagePreview');
            const wasCover = preview.classList.contains('cover');
            preview.remove();

            if (wasCover) {
                const firstPreview = document.querySelector('.ev-imagePreview');
                if (firstPreview) {
                    firstPreview.classList.add('cover');
                    firstPreview.querySelector('.btn-cover i').className = 'bi-star-fill';
                }
            }
        }
    });
}