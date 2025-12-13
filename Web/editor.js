// Ribbon data structure
const ribbonData = {
    "Start": [
        { name: "Get Started", id: "ZeroDoc" },
        { name: "Tools", id: "id_TabTools" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" }
    ],
    "Part": [
        { name: "Sheet Metal", id: "id_TabSheetMetal" },
        { name: "Flat Pattern", id: "id_TabFlatPattern" },
        { name: "Model", id: "id_TabModel" },
        { name: "Inspect", id: "id_TabInspect" },
        { name: "Tools", id: "id_TabTools" },
        { name: "Manage", id: "id_TabManage" },
        { name: "View", id: "id_TabView" },
        { name: "Environments", id: "id_TabEnvironments" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Sketch", id: "id_TabSketch" },
        { name: "Exit 2D Sketch", id: "id_TabSketch_Exit" },
        { name: "3D Sketch", id: "id_Tab3DSketch" },
        { name: "Exit 3D Sketch", id: "id_Tab3DSketch_Exit" },
        { name: "Construction", id: "id_TabConstruction" },
        { name: "Exit Construction", id: "id_TabConstruction_Exit" },
        { name: "Edit Base Solid", id: "id_TabEditBaseSolid" },
        { name: "Exit Base Solid", id: "id_TabEditBaseSolid_Exit" },
        { name: "Repair", id: "id_TabSurfaceRepair" },
        { name: "Exit Repair", id: "id_TabSurfaceRepair_Exit" },
        { name: "Route", id: "id_TabRoute" },
        { name: "Exit Route", id: "id_TabRoute_Exit" },
        { name: "Render", id: "id_TabRender" },
        { name: "Exit Studio", id: "id_TabRender_Exit" },
        { name: "Exit Stress Analysis", id: "id_TabStressAnalysis_Exit" },
        { name: "Stress Analysis", id: "id_TabAFEA" },
        { name: "Exit Stress Analysis", id: "id_TabAFEA_Exit" },
        { name: "BIM Exchange", id: "id_TabAECExchange" },
        { name: "Exit BIM Exchange", id: "id_TabAECExchange_Exit" },
        { name: "Return", id: "id_TabReturn" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" },
        { name: "Fusion Change Manager", id: "FTC.Tab" }
    ],
    "Assembly": [
        { name: "Mold Layout", id: "MoldTabLayout" },
        { name: "Core/Cavity", id: "MoldTabCoreCavity" },
        { name: "Mold Assembly", id: "MoldTabMoldBase" },
        { name: "Assemble", id: "id_TabAssemble" },
        { name: "Design", id: "id_TabDesign" },
        { name: "Model", id: "id_TabModel" },
        { name: "Weld", id: "id_TabWeld" },
        { name: "Weld Return to Parent", id: "id_TabWeld_ReturnParent" },
        { name: "Inspect", id: "id_TabInspect" },
        { name: "Tools", id: "id_TabTools" },
        { name: "Manage", id: "id_TabManage" },
        { name: "View", id: "id_TabView" },
        { name: "Environments", id: "id_TabEnvironments" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Sketch", id: "id_TabSketch" },
        { name: "Exit 2D Sketch", id: "id_TabSketch_Exit" },
        { name: "Tube and Pipe", id: "id_TabTube_Pipe" },
        { name: "Exit Tube and Pipe", id: "id_TabTube_Pipe_Exit" },
        { name: "Pipe Run", id: "id_TabTube_Pipe_Run" },
        { name: "Exit Tube and Pipe Run", id: "id_TabTube_Pipe_Run_Exit" },
        { name: "Cable and Harness", id: "id_TabCable_Harness" },
        { name: "Exit Cable and Harness", id: "id_TabCable_Harness_Exit" },
        { name: "Render", id: "id_TabRender" },
        { name: "Exit Studio", id: "id_TabRender_Exit" },
        { name: "Dynamic Simulation", id: "id_TabSimulation" },
        { name: "Exit Dynamic Simulation", id: "id_TabSimulation_Exit" },
        { name: "BIM Exchange", id: "id_TabAECExchange" },
        { name: "Exit BIM Exchange", id: "id_TabAECExchange_Exit" },
        { name: "Return", id: "id_TabReturn" },
        { name: "Stress Analysis", id: "id_TabAFEA" },
        { name: "Exit Stress Analysis", id: "id_TabAFEA_Exit" },
        { name: "Frame Analysis", id: "id_TabIFA" },
        { name: "Exit Frame Analysis", id: "id_TabIFA_Exit" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" }
    ],
    "Drawing": [
        { name: "Place Views", id: "id_TabPlaceViews" },
        { name: "Annotate", id: "id_TabAnnotate" },
        { name: "Annotate (ESKD)", id: "id_TabAnnotateESKD" },
        { name: "Tools", id: "id_TabTools" },
        { name: "Manage", id: "id_TabManage" },
        { name: "View", id: "id_TabView" },
        { name: "Environments", id: "id_TabEnvironments" },
        { name: "Nailboard", id: "id_TabNailboard" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Sketch", id: "id_TabSketch" },
        { name: "Exit 2D Sketch", id: "id_TabSketch_Exit" },
        { name: "Exit Nailboard Sketch", id: "id_TabNailboard_Exit" },
        { name: "Review", id: "id_TabReview" },
        { name: "Exit Review", id: "id_TabNailboard_Review" },
        { name: "Return", id: "id_TabReturn" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" }
    ],
    "Presentation": [
        { name: "Presentation", id: "id_TabManage" },
        { name: "Tools", id: "id_TabTools" },
        { name: "View", id: "id_TabView" },
        { name: "Environments", id: "id_TabEnvironments" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Return", id: "id_TabReturn" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" }
    ],
    "iFeatures": [
        { name: "iFeature", id: "id_TabiFeature" },
        { name: "Tools", id: "id_TabTools" },
        { name: "View", id: "id_TabView" },
        { name: "Environments", id: "id_TabEnvironments" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Add-Ins", id: "id_AddInsTab" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" }
    ],
    "UnknownDocument": [
        { name: "Custom View", id: "id_TabCustomView" },
        { name: "Engineer's Notebook", id: "id_TabEngineersNotebook" },
        { name: "Tools", id: "id_TabEngineersNotebookTools" },
        { name: "View", id: "id_TabEngineersNotebookView" },
        { name: "Vault", id: "id_TabVault" },
        { name: "Vault", id: "id_TabVault_Upgrade" },
        { name: "Get Started", id: "id_GetStarted" },
        { name: "Inventor Debug", id: "id_InventorDebugTab" },
        { name: "Add-Ins", id: "id_AddInsTab" }
    ]
};

// Store entries
let entries = [];
let selectedTabIds = [];
let buttonCounter = 1;
let currentSmallImage = null;
let currentLargeImage = null;

// Initialize
document.addEventListener('DOMContentLoaded', function() {
    console.log('Editor initialized');
    console.log('Ribbon element:', document.getElementById('ribbonName'));
    console.log('Tab element:', document.getElementById('tabId'));
    
    document.getElementById('ribbonName').addEventListener('change', updateTabOptions);
    
    const form = document.getElementById('buttonForm');
    console.log('Form element:', form);
    form.addEventListener('submit', function(e) {
        e.preventDefault();
        console.log('Submit event triggered - default prevented');
        handleFormSubmit(e);
    });
    
    console.log('Event listeners attached');
});

// Update tab options based on selected ribbon
function updateTabOptions() {
    console.log('updateTabOptions called');
    const ribbonName = document.getElementById('ribbonName').value;
    console.log('Selected ribbon:', ribbonName);
    const tabSelect = document.getElementById('tabId');
    
    // Clear existing options
    tabSelect.innerHTML = '<option value="">Select Tab...</option>';
    
    if (ribbonName && ribbonData[ribbonName]) {
        console.log('Loading tabs for:', ribbonName, 'Count:', ribbonData[ribbonName].length);
        ribbonData[ribbonName].forEach(tab => {
            const option = document.createElement('option');
            option.value = tab.id;
            option.textContent = tab.name;
            tabSelect.appendChild(option);
        });
    }
    
    // Clear selected tabs when ribbon changes
    selectedTabIds = [];
}

// Add tab ID to selection
function addTabId() {
    console.log('addTabId called');
    const tabSelect = document.getElementById('tabId');
    const selectedValue = tabSelect.value;
    const selectedText = tabSelect.options[tabSelect.selectedIndex].text;
    
    console.log('Selected value:', selectedValue, 'Text:', selectedText);
    
    if (!selectedValue || selectedValue === '') {
        showAlert('Please select a tab from the dropdown', 'error');
        return;
    }
    
    if (selectedValue && !selectedTabIds.includes(selectedValue)) {
        selectedTabIds.push(selectedValue);
        console.log('Tab added. Total tabs:', selectedTabIds.length);
        updateSelectedTabsDisplay();
    } else {
        console.log('Tab not added - already exists or no value');
    }
}

// Update display of selected tabs
function updateSelectedTabsDisplay() {
    const container = document.getElementById('selectedTabs');
    const ribbonName = document.getElementById('ribbonName').value;
    
    if (selectedTabIds.length === 0) {
        container.innerHTML = '';
        return;
    }
    
    container.innerHTML = '';
    
    selectedTabIds.forEach(tabId => {
        const tabInfo = ribbonData[ribbonName]?.find(t => t.id === tabId);
        const badge = document.createElement('div');
        badge.className = 'badge-tab';
        badge.innerHTML = `
            <span>${tabInfo ? tabInfo.name : tabId}</span>
            <button type="button" class="btn-close btn-close-white" onclick="removeTabId('${tabId}')" aria-label="Remove"></button>
        `;
        container.appendChild(badge);
    });
}

// Remove tab ID from selection
function removeTabId(tabId) {
    selectedTabIds = selectedTabIds.filter(id => id !== tabId);
    updateSelectedTabsDisplay();
}

// Validate image dimensions
function validateImage(inputId, expectedWidth, expectedHeight) {
    const input = document.getElementById(inputId);
    const file = input.files[0];
    
    if (!file) {
        return;
    }
    
    if (!file.type.match('image/png')) {
        showAlert('Please select a PNG image file', 'error');
        input.value = '';
        return;
    }
    
    const img = new Image();
    const reader = new FileReader();
    
    reader.onload = function(e) {
        img.onload = function() {
            if (img.width === expectedWidth && img.height === expectedHeight) {
                // Valid image
                const previewDiv = document.getElementById(inputId + 'Preview');
                const previewImg = document.getElementById(inputId + 'Img');
                const previewName = document.getElementById(inputId + 'Name');
                
                previewImg.src = e.target.result;
                previewName.textContent = file.name;
                previewDiv.classList.add('show');
                
                // Store image data
                if (inputId === 'smallImage') {
                    currentSmallImage = { name: file.name, data: e.target.result };
                } else {
                    currentLargeImage = { name: file.name, data: e.target.result };
                }
                
                showAlert(`Image validated: ${expectedWidth}x${expectedHeight}`, 'success');
            } else {
                showAlert(`Image must be exactly ${expectedWidth}x${expectedHeight} pixels. Your image is ${img.width}x${img.height}`, 'error');
                input.value = '';
                document.getElementById(inputId + 'Preview').classList.remove('show');
            }
        };
        img.src = e.target.result;
    };
    
    reader.readAsDataURL(file);
}

// Handle form submission
function handleFormSubmit(e) {
    e.preventDefault();
    console.log('Form submitted');
    console.log('Selected tabs:', selectedTabIds);
    console.log('Small image:', currentSmallImage);
    console.log('Large image:', currentLargeImage);
    
    if (selectedTabIds.length === 0) {
        showAlert('Please add at least one Tab ID', 'error');
        return;
    }
    
    if (!currentSmallImage || !currentLargeImage) {
        showAlert('Please upload both small (16x16) and large (32x32) images', 'error');
        return;
    }
    
    const entry = {
        RibbonName: document.getElementById('ribbonName').value,
        TabId: selectedTabIds.join(','),
        DisplayName: document.getElementById('displayName').value,
        InternalId: document.getElementById('internalId').value,
        Tooltip: document.getElementById('tooltip').value,
        SmallImage: currentSmallImage.name.replace('.png', ''),
        LargeImage: currentLargeImage.name.replace('.png', ''),
        PanelId: document.getElementById('panelId').value,
        PanelName: document.getElementById('panelName').value,
        Handler: document.getElementById('handler').value,
        SmallImageData: currentSmallImage.data,
        LargeImageData: currentLargeImage.data
    };
    
    console.log('Entry created:', entry);
    entries.push(entry);
    console.log('Total entries:', entries.length);
    buttonCounter++;
    
    updateEntriesList();
    clearForm();
    
    // Auto-fill panel fields with last entry's data
    if (entries.length > 0) {
        const lastEntry = entries[entries.length - 1];
        document.getElementById('panelId').value = lastEntry.PanelId;
        document.getElementById('panelName').value = lastEntry.PanelName;
    }
    
    showAlert('Entry added successfully!', 'success');
}

// Update entries list display
function updateEntriesList() {
    const container = document.getElementById('entriesList');
    const countElement = document.getElementById('entryCount');
    
    countElement.textContent = entries.length;
    
    if (entries.length === 0) {
        container.innerHTML = '<div class="empty-state">No entries yet. Add your first button configuration above.</div>';
        return;
    }
    
    container.innerHTML = '';
    
    entries.forEach((entry, index) => {
        const item = document.createElement('div');
        item.className = 'entry-item';
        item.innerHTML = `
            <div class="d-flex align-items-center flex-grow-1">
                <img src="${entry.LargeImageData}" alt="${entry.DisplayName}">
                <div class="entry-info">
                    <strong>${entry.DisplayName}</strong>
                    <span>${entry.RibbonName} - ${entry.InternalId} - Handler: ${entry.Handler}</span>
                </div>
            </div>
            <button class="btn btn-danger btn-sm" onclick="removeEntry(${index})">Remove</button>
        `;
        container.appendChild(item);
    });
}

// Remove entry
function removeEntry(index) {
    entries.splice(index, 1);
    updateEntriesList();
    showAlert('Entry removed', 'success');
}

// Clear all entries
function clearAllEntries() {
    if (entries.length === 0) return;
    
    if (confirm('Are you sure you want to clear all entries?')) {
        location.reload();
    }
}

// Clear form
function clearForm() {
    document.getElementById('buttonForm').reset();
    selectedTabIds = [];
    currentSmallImage = null;
    currentLargeImage = null;
    updateSelectedTabsDisplay();
    updateTabOptions();
    document.getElementById('smallImagePreview').classList.remove('show');
    document.getElementById('largeImagePreview').classList.remove('show');
}

// Show alert
function showAlert(message, type) {
    const container = document.getElementById('alert-container');
    const alert = document.createElement('div');
    alert.className = `alert alert-${type === 'error' ? 'danger' : 'success'} alert-dismissible fade show`;
    alert.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;
    
    container.innerHTML = '';
    container.appendChild(alert);
    
    setTimeout(() => {
        alert.remove();
    }, 3000);
}

// Generate files
function generateFiles() {
    if (entries.length === 0) {
        showAlert('Please add at least one entry before generating files', 'error');
        return;
    }
    
    // Generate ButtonCfg.json (without image data)
    const buttonCfgData = entries.map(entry => {
        const { SmallImageData, LargeImageData, ...entryWithoutImageData } = entry;
        return entryWithoutImageData;
    });
    const buttonCfgJson = JSON.stringify(buttonCfgData, null, 2);
    
    // Generate Code.txt
    const handlers = [...new Set(entries.map(e => e.Handler))];
    const codeTxt = generateCodeFile(handlers, entries);
    
    // Download files
    downloadFile('ButtonCfg.json', buttonCfgJson);
    downloadFile('Code.txt', codeTxt);
    
    // Download unique images
    const downloadedImages = new Set();
    entries.forEach(entry => {
        // Download small image (16x16)
        if (entry.SmallImageData && !downloadedImages.has(entry.SmallImage)) {
            downloadImage(entry.SmallImage + '.png', entry.SmallImageData);
            downloadedImages.add(entry.SmallImage);
        }
        // Download large image (32x32)
        if (entry.LargeImageData && !downloadedImages.has(entry.LargeImage)) {
            downloadImage(entry.LargeImage + '.png', entry.LargeImageData);
            downloadedImages.add(entry.LargeImage);
        }
    });
    
    showAlert('Files and images downloaded successfully!', 'success');
}

// Generate code file content
function generateCodeFile(handlers, entries) {
    let code = "'----------------------------------------------------------\n";
    code += "'******** Register built-in handler factories here ********\n\n";
    
    handlers.forEach(handler => {
        code += `handlerFactories.Add("${handler}", AddressOf Make${handler})\n`;
    });
    
    code += "\n'----------------------------------------------------------\n\n\n\n";
    code += "'-----------------------------------------------------------------------\n";
    code += "' ******* Handler factory helpers  *************************************\n\n";
    
    handlers.forEach(handler => {
        const entry = entries.find(e => e.Handler === handler);
        code += `Private Function Make${handler}(cfg As ButtonConfig) As RibbonExecuteHandler\n`;
        code += `\tReturn New RibbonExecuteHandler(Sub(ctx As NameValueMap)\n`;
        code += `\t\tMsgBox(cfg.DisplayName)\n`;
        code += `\tEnd Sub)\n`;
        code += `End Function\n\n`;
    });
    
    code += "'-----------------------------------------------------------------------\n";
    code += "'-----------------------------------------------------------------------\n";
    
    return code;
}

// Download file
function downloadFile(filename, content) {
    const blob = new Blob([content], { type: 'text/plain' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}

// Download image from base64 data
function downloadImage(filename, base64Data) {
    const a = document.createElement('a');
    a.href = base64Data;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
}

// Show files on page
function showFilesOnPage() {
    if (entries.length === 0) {
        showAlert('Please add at least one entry before generating files', 'error');
        return;
    }
    
    // Generate ButtonCfg.json (without image data)
    const buttonCfgData = entries.map(entry => {
        const { SmallImageData, LargeImageData, ...entryWithoutImageData } = entry;
        return entryWithoutImageData;
    });
    const buttonCfgJson = JSON.stringify(buttonCfgData, null, 2);
    
    // Generate Code.txt
    const handlers = [...new Set(entries.map(e => e.Handler))];
    const codeTxt = generateCodeFile(handlers, entries);
    
    // Display in textareas
    document.getElementById('buttonCfgPreview').value = buttonCfgJson;
    document.getElementById('codePreview').value = codeTxt;
    document.getElementById('filePreview').style.display = 'block';
    
    // Scroll to preview
    document.getElementById('filePreview').scrollIntoView({ behavior: 'smooth' });
    
    showAlert('Files generated and displayed below!', 'success');
}

// Copy to clipboard
function copyToClipboard(elementId) {
    const textarea = document.getElementById(elementId);
    textarea.select();
    document.execCommand('copy');
    
    const filename = elementId === 'buttonCfgPreview' ? 'ButtonCfg.json' : 'Code.txt';
    showAlert(`${filename} copied to clipboard!`, 'success');
}