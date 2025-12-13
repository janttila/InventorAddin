# Button Configuration Editor

A web-based editor for creating Autodesk Inventor add-in button configurations. This tool helps you generate `ButtonCfg.json` and `Code.txt` files along with the required ribbon button images.

## Features

- **Ribbon & Tab Selection**: Choose from 7 different ribbon types with their associated tabs
- **Multi-Tab Support**: Add buttons to multiple tabs at once
- **Image Upload & Validation**: 
  - Validates PNG images for exact dimensions (16x16 and 32x32 pixels)
  - Preview uploaded images before adding
- **Auto-Fill Panel Fields**: Panel ID and Panel Name auto-fill from the previous entry
- **Entry Management**: View, edit, and remove button entries
- **File Generation**: 
  - Downloads `ButtonCfg.json` with all button configurations
  - Downloads `Code.txt` with VB.NET handler code templates
  - Downloads all button images (16x16 and 32x32 PNG files)
- **Modern UI**: Clean Bootstrap Flatly theme with responsive design

## How to Use

### 1. Open the Editor
Open `editor.html` in your web browser.

### 2. Select Ribbon
Choose the ribbon type from the dropdown:
- Assembly
- Part
- Drawing
- Sketch
- PresentationEnvironment
- ZeroDoc
- AllEnvironments

### 3. Add Tab IDs
1. Select a tab from the dropdown (tabs are filtered based on the selected ribbon)
2. Click **Add Tab** button
3. Repeat to add multiple tabs
4. Remove tabs by clicking the ✕ on the badge

### 4. Upload Images
- **Small Image (16x16)**: Upload a 16x16 pixel PNG file
- **Large Image (32x32)**: Upload a 32x32 pixel PNG file
- Images are validated automatically - you'll see an error if dimensions are incorrect

### 5. Fill in Button Details
- **Display Name**: The text shown on the button
- **Internal ID**: Unique identifier for the button
- **Tooltip**: Hover text for the button
- **Panel ID**: Panel identifier (auto-fills from previous entry)
- **Panel Name**: Panel display name (auto-fills from previous entry)
- **Handler**: Function name for the button click handler

### 6. Add Entry
Click **Add Entry** to save the button configuration. The entry will appear in the list below.

### 7. Manage Entries
- View all entries with their images and details
- Click **Remove** to delete an entry
- Click **Clear All** to start over (page will reload)

### 8. Generate Files
Click **Download Files** to download:
- `ButtonCfg.json` - JSON configuration file
- `Code.txt` - VB.NET handler code template
- All unique button images (16x16 and 32x32 PNG files)

### 9. Preview Files (Optional)
Click **Show Files on Page** to preview the generated files in the browser before downloading.

## File Structure

### ButtonCfg.json
Contains an array of button configurations with properties:
- `RibbonName`: The ribbon type
- `TabId`: Comma-separated list of tab IDs
- `DisplayName`: Button display text
- `InternalId`: Unique button identifier
- `Tooltip`: Button tooltip text
- `SmallImage`: 16x16 image filename (without .png)
- `LargeImage`: 32x32 image filename (without .png)
- `PanelId`: Panel identifier
- `PanelName`: Panel display name
- `Handler`: Handler function name

### Code.txt
VB.NET code template containing:
- Handler factory registrations
- Handler factory helper functions with message box templates

### Image Files
- PNG files named as specified in SmallImage and LargeImage fields
- Automatically downloaded with correct filenames

## Validation Rules

- At least one tab must be selected
- Both small (16x16) and large (32x32) images are required
- Images must be PNG format
- Images must have exact dimensions (16x16 or 32x32)
- Tab selection shows error if no tab is selected

## Tips

- The Panel ID and Panel Name fields auto-fill from your last entry to speed up data entry when multiple buttons belong to the same panel
- All validation messages appear at the top center of the screen
- Images are validated immediately upon selection
- You can add the same button to multiple tabs by selecting multiple tabs before clicking Add Entry
- Image files are only downloaded once even if used in multiple entries

## Browser Compatibility

Works in all modern browsers that support:
- HTML5 File API
- ES6 JavaScript
- CSS Grid and Flexbox

## Troubleshooting

**Tab dropdown is empty**: Make sure you've selected a ribbon type first

**Image validation fails**: Ensure your PNG files are exactly 16x16 or 32x32 pixels

**Can't see validation messages**: Messages appear fixed at the top center of the screen - they scroll into view automatically

**Downloads not working**: Check your browser's download settings and popup blocker

## Files

- `editor.html` - Main HTML file with the form and UI
- `editor.js` - JavaScript functionality for validation, file generation, and downloads
- `README.md` - This help file
