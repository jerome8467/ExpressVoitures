Dropzone.autoDiscover = false;
let uploadedFiles = [];

document.addEventListener('DOMContentLoaded', () => {

    // Flatpickr dates
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

    // Synchronisation des champs visuels vers les hidden au submit
    const form = document.getElementById('addCarForm');
    if (form) {
        form.addEventListener('submit', function () {
            document.getElementById('hiddenKilometer').value = document.getElementById('visuelKilometer').value;
            document.getElementById('hiddenYear').value = document.getElementById('visuelYear').value;
            document.getElementById('hiddenDescription').value = document.getElementById('visuelDescription').value;
            document.getElementById('hiddenRepairPrice').value = document.getElementById('visuelRepairPrice').value;
            document.getElementById('hiddenTypeOfRepair').value = document.getElementById('visuelTypeOfRepair').value;
            document.getElementById('hiddenPurchasePrice').value = document.getElementById('visuelPurchasePrice').value;
            document.getElementById('hiddenAdditionalAmount').value = document.getElementById('visuelAdditionalAmount').value;

            // Ajout des fichiers Dropzone au formulaire
            uploadedFiles.forEach(file => {
                const input = document.createElement('input');
                input.type = 'file';
                const dt = new DataTransfer();
                dt.items.add(file);
                input.files = dt.files;
                input.name = 'images';
                input.style.display = 'none';
                form.appendChild(input);
            });
        });
    }

    // Params URL manufacturer/vehiclemodel/finition
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

    // TomSelect année
    if (document.getElementById('visuelYear')) {
        new TomSelect('#visuelYear', {
            maxOptions: null,
            controlInput: null
        });
    }

    // Dropzone
    if (document.getElementById('imageDropzone')) {
        const myDropzone = new Dropzone("#imageDropzone", {
            url: "/CarAdmin/UploadImage",
            acceptedFiles: "image/*",
            addRemoveLinks: false,
            autoProcessQueue: false,
            thumbnailWidth: 120,
            thumbnailHeight: 120,
            previewsContainer: false,
            init: function () {
                this.on("addedfile", function (file) {
                    uploadedFiles.push(file);
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
                    preview._dropzoneFile = file;
                    if (document.querySelectorAll('.ev-imagePreview').length === 1) {
                        setCover(preview);
                    }
                    preview.querySelector('.btn-cover').addEventListener('click', () => setCover(preview));
                    preview.querySelector('.btn-remove').addEventListener('click', () => removeImage(preview, file));
                });
            }
        });
    }

});

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

function removeImage(preview, file) {
    uploadedFiles = uploadedFiles.filter(f => f !== file);
    preview.remove();
}