function ChangeImage(uploadImg, previewImg) {
    if (uploadImg.files && uploadImg.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg).attr('src', e.target.result);
        }
        reader.readAsDataURL(uploadImg.files[0]);
    }
}
