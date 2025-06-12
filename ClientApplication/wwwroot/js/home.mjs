import { getAccessTokenFromCookie, getNameFromToken, getRoleFromToken } from './token-parser.mjs';
import { getAllPromotionalImages, uploadPromotionalImages } from './api.mjs';


export function loadHomePage() {
    const token = getAccessTokenFromCookie();
    const welcomeElement = document.getElementById("welcome-message");
    let userName = null;
    let userRole = null;
    let welcomeMessageText = "Welcome";

    if (token) {
        userName = getNameFromToken(token);
        userRole = getRoleFromToken(token);

        if (userRole === "Manager") {
            loadImageUploadForm(token);
        }
        welcomeMessageText += ` ${userName}`;
    }

    loadCarousel();
   
    welcomeElement.textContent = welcomeMessageText;
}


function loadCarousel() {
    const carouselElement = document.getElementById("carousel");
    const carouselErrorTextElement = document.getElementById("carousel-error-text");
    const carouselLoadingTextElement = document.getElementById("carousel-loading-text");


    carouselLoadingTextElement.textContent = "Loading promotional images...";
    getAllPromotionalImages().then(images => {
        const carouselInnerElement = document.createElement("div");
        carouselInnerElement.classList.add("carousel-inner");
        let itemCount = 0;
        images.forEach(image => {
            itemCount++;
            const carouselItemElement = document.createElement("div");
            carouselItemElement.classList.add("carousel-item");
            if (itemCount === 1) {
                carouselItemElement.classList.add("active");
            }
            const imgElement = document.createElement("img");
            imgElement.src = image;
            imgElement.alt = `Slide ${itemCount}`;
            imgElement.classList.add("carousel-image");
            imgElement.classList.add("dblock");
            imgElement.classList.add("w-100");
            carouselItemElement.appendChild(imgElement);
            carouselInnerElement.appendChild(carouselItemElement);
        });
        carouselElement.replaceChildren(carouselInnerElement);
        const carouselControlPrev = document.createElement("button");
        carouselControlPrev.classList.add("carousel-control-prev");
        carouselControlPrev.setAttribute("data-bs-target", "#carousel");
        carouselControlPrev.setAttribute("data-bs-slide", "prev");
        const carouselControlPrevIcon = document.createElement("span");
        carouselControlPrevIcon.classList.add("carousel-control-prev-icon");
        carouselControlPrevIcon.setAttribute("aria-hidden", "true");
        carouselControlPrev.appendChild(carouselControlPrevIcon);
        const carouselControlPreviousText = document.createElement("span");
        carouselControlPreviousText.classList.add("visually-hidden");
        carouselControlPreviousText.textContent = "Previous";
        carouselControlPrev.appendChild(carouselControlPreviousText);
        const carouselControlNext = document.createElement("button");
        carouselControlNext.classList.add("carousel-control-next");
        carouselControlNext.setAttribute("data-bs-target", "#carousel");
        carouselControlNext.setAttribute("data-bs-slide", "next");
        const carouselControlNextIcon = document.createElement("span");
        carouselControlNextIcon.classList.add("carousel-control-next-icon");
        carouselControlNextIcon.setAttribute("aria-hidden", "true");
        carouselControlNext.appendChild(carouselControlNextIcon);
        const carouselControlNextText = document.createElement("span");
        carouselControlNextText.classList.add("visually-hidden");
        carouselControlNextText.textContent = "Next";
        carouselControlNext.appendChild(carouselControlNextText);
        carouselElement.appendChild(carouselControlPrev);
        carouselElement.appendChild(carouselControlNext);
        carouselLoadingTextElement.textContent = "";
    }).catch(error => {
        if (error.message.includes("404")) {
            carouselErrorTextElement.textContent = "Endpoint not found";
        } else if (error.message.includes("400")) {
            carouselErrorTextElement.textContent = "Invalid date was passed";
        } else if (error.message.includes("500")) {
            carouselErrorTextElement.textContent = "Internal server error";
        } else {
            carouselErrorTextElement.textContent = "Unknown error";
        }
        carouselLoadingTextElement.textContent = "";
    });
}


function loadImageUploadForm(token) {
    const uploadFormContainerElement = document.getElementById("upload-form-container");
    const uploadErrorTextElement = document.getElementById("upload-error-text");
    const uploadSuccessTextElement = document.getElementById("upload-success-text");
    const uploadFormElement = document.createElement("form");

    uploadFormElement.id = "upload-form";
    uploadFormElement.setAttribute("enctype", "multipart/form-data");
    uploadFormElement.setAttribute("action", "post");
    uploadFormElement.classList.add("mb-4");
    uploadFormElement.innerHTML = `
                <div class="mb-3">
                    <label for="form-file-multiple class="form-label">Upload Images (JPEG or PNG):</label>
                    <input class="form-control"
                           type="file"
                           id="form-file-multiple"
                           name="files"
                           multiple
                           accept=".png, .jpeg, .jpg" />
                </div>
                <input id="upload-btn" class="btn btn-primary" type="button" value="Upload" />
            `;
    uploadFormContainerElement.appendChild(uploadFormElement);
    const fileInputElement = document.getElementById("form-file-multiple");
    const uploadBtn = document.getElementById("upload-btn");
    uploadBtn.addEventListener("click", function (e) {
        e.preventDefault();
        if (!fileInputElement.files || fileInputElement.files.length === 0) {
            uploadErrorTextElement.textContent = "Please select at least one image to upload.";
            uploadSuccessTextElement.textContent = "";
            return;
        }
        const formData = new FormData();

        for (const file of fileInputElement.files) {
            if (!file.type.startsWith("image/jpeg") && !file.type.startsWith("image/png")) {
                uploadErrorTextElement.textContent = "Only JPEG and PNG files are allowed.";
                return;
            }
            formData.append("files", file, file.name);
        }

        uploadPromotionalImages(formData, token).then(() => {
            uploadSuccessTextElement.textContent = "Images uploaded successfully!";
            loadCarousel();
        });
    });
}