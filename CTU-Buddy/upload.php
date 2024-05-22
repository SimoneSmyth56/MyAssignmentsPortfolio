<?php
$uploadDirectory = "FileUploads/";

if ($_FILES["uploadedFile"]["error"] == UPLOAD_ERR_OK) {
    $tmpName = $_FILES["uploadedFile"]["tmp_name"];
    $fileName = $_FILES["uploadedFile"]["name"];
    $destination = $uploadDirectory . $fileName;

    if (move_uploaded_file($tmpName, $destination)) {
        echo "File successfully uploaded to $destination";
    } else {
        echo "Error uploading file.";
    }
} else {
    echo "File upload error: " . $_FILES["uploadedFile"]["error"];
}
?>