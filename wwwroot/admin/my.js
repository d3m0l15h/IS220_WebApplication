/* Form Popup */
function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
function previewAvatar() {
    const preview = document.querySelector('#imagePreview');
    const file = document.querySelector('#upload').files[0];
    const reader = new FileReader();

    reader.onloadend = function (e) {
        preview.src = reader.result;
        preview.style.display = 'block';
        
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
        preview.style.display = 'none';
    }
}
function previewImage() {
    const preview = document.querySelector('#imagePreview');
    const file = document.querySelector('#upload').files[0];
    const reader = new FileReader();

    reader.onloadend = function (e) {
        preview.src = reader.result;
        preview.style.display = 'block';
        document.getElementById('imgSize').textContent = 'Size: ' + (file.size / 1024).toFixed(2) + ' KB';
        document.getElementById('imgName').textContent = 'Name: ' + file.name;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
        preview.style.display = 'none';
    }
}

function formatNumber(n) {
    if (!n) return '';
    // Convert to string
    var asString = n.toString();

    // Split the string into whole and fractional parts (if any)
    var parts = asString.split(".");

    // Add commas to the whole part
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");

    // Return the formatted number
    return parts.join(".");
}

// Call the function when the input value changes
document.addEventListener('DOMContentLoaded', function() {
    var gamePriceInput = document.querySelector('input[name="Game.Price"]');
    if(gamePriceInput) {
        gamePriceInput.addEventListener('input', function (e) {
            e.target.value = formatNumber(e.target.value.replace(/,/g, ''));
        });
    }
});

var popupWindow = null;
function openPopupWindow(url) {
    if (!popupWindow || popupWindow.closed) {
        popupWindow = window.open(url, '_blank', 'location=yes,height=280,width=500,scrollbars=yes,status=yes');
    } else {
        popupWindow.focus();
    }
}
function addWindow(entity){
    // Construct the URL for the add action
    var url = 'http://localhost:5249/admin/' + entity + '/add';

    // Open a new window with the constructed URL
    openPopupWindow(url);
}
function deleteWindow(entity, element){
    // Get the selected value from the select option
    var selectedValue = Number.isInteger(element) ? element : document.getElementsByName(element)[0].value;

    // Construct the URL for the delete action
    var url = 'http://localhost:5249/admin/' + entity + '/delete/' + selectedValue;
    
    // Open a new window with the constructed URL
    openPopupWindow(url);
}
function editWindow(entity, element) {
    // Get the selected value from the select option
    var selectedValue = Number.isInteger(element) ? element : document.getElementsByName(element)[0].value;

    // Construct the URL for the delete action
    var url = 'http://localhost:5249/admin/' + entity + '/edit/' + selectedValue;

    // Open a new window with the constructed URL
    openPopupWindow(url);
}
function entityAdded(id, name, element) {
    // Close the popup window
    if (window.popupWindow) {
        window.popupWindow.close();
    }

    // Update the select in the parent window
    var select = document.getElementsByName(element)[0];
    var option = new Option(name, id);
    select.appendChild(option);
    select.value = id; // Select the new option
    $('select[name="'+element+'"]').select2();
}
function entityDeleted(id, element) {
    // Close the popup window
    if (window.popupWindow) {
        window.popupWindow.close();
    }
    
    // Remove the option from the select in the parent window
    var select = document.getElementsByName(element)[0];
    var options = select.options;
    for (var i = 0; i < options.length; i++) {
        if (options[i].value === id.toString()) {
            select.removeChild(options[i]);
            $('select[name="'+element+'"]').select2();
            break;
        }
    }
}

function entityEdited(id, name, element) {
    // Close the popup window
    if (window.popupWindow) {
        window.popupWindow.close();
    }

    // Update the select in the parent window
    var select = document.getElementsByName(element)[0];
    var options = select.options;
    for (var i = 0; i < options.length; i++) {
        if (options[i].value === id.toString()) {
            options[i].text = name;
            $('select[name="'+element+'"]').select2();
            break;
        }
    }
}

document.getElementById('upImage').addEventListener('click', function() {
    document.getElementById('upload').click();
});


