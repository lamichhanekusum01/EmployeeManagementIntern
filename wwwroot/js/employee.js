function Toast(timeInterval, toastType) {
    debugger
    var toastDiv = document.createElement("div");
    toastDiv.id = "toastr";
    toastDiv.className = "toastr";
    var body = document.getElementsByTagName("body")[0].appendChild(toastDiv);

    var fontDiv = document.createElement("i");
    fontDiv.className = "far fa-check-circle";
    toastDiv.appendChild(fontDiv);

    var paragraphText = document.createElement("p");
    paragraphText.className = "toastPara";
    paragraphText.textContent = "Submitted";
    toastDiv.appendChild(paragraphText);


    if (timeInterval == undefined) {
        //if timeinterval is not provided, add defualt timeinterval 3s.
        timeInterval = 3000;
    }
    if (toastType == undefined) {
        toastDiv.style.backgroundColor = "#088b08f2";
        paragraphText.textContent = "Sucessfully Submitted";
        fontDiv.className = "far fa-check-circle";
    } else if (toastType == "warning") {
        toastDiv.style.backgroundColor = "rgb(236 50 50 / 87%)";
        paragraphText.style.color = "white";
        fontDiv.className = "far fa-times-circle";
        paragraphText.textContent = "Error";
    }

    // var a = document.getElementById("toastr");
    // a.className = "show";

    setTimeout(function () {
        a.className = a.className.replace("show", "");
    }, timeInterval);

    var a = document.getElementById("toastr");
    a.className = "show";
    setTimeout(function () {
        a.className = a.className.replace("show", "");
    }, 3000);
}


// var paragraph = document.createElement("p");
// paragraph.className = "toast";
// paragraph.textContent = "Submitted by";
// toastDiv.appendChild(paragraph);

buttonDiv = document.createElement("div");
document.getElementsByTagName("body")[0].appendChild(buttonDiv);

function openForm() {
    if (document.getElementById("myForm")) {
        document.getElementById("myForm").style.display = " block";
        document.getElementById("myForm").classList.add("opened");
    }
}

function closeForm() {
    if (document.getElementById("myForm")) {
        document.getElementById("myForm").style.display = "none";
        document.getElementById("myForm").classList.remove("opened");
    }
}

// function validateForm() {
//   let xForm = document.forms["user-form"]["fname"].value;
//   if (xForm == "") {
//     alert("Name must be filled out");
//     return false;
//   }
// }
let y = document.querySelector(".iconImage span");
let x = document.querySelector(".closebtn");
// let z=document.querySelector(".open-button"); // console.log('open-button')
y.addEventListener("click", () => {
    // z.classList.add("showbar");
    document.querySelector(".mysidenav").classList.add("showbar");
});
x.addEventListener("click", () => {
    // z.classList.add("showbar");
    document.querySelector(".mysidenav").classList.remove("showbar");
});
window.addEventListener("click", function (e) {
    // console.log(e.target.parentElement)
    var element = document.getElementById("myForm");
    var imgItm = document.querySelector(".imgContainer img");

    if (e.target !== element && !element.contains(e.target)) {
        if (element.classList.contains("opened") && e.target !== imgItm) {
            closeForm();
            // console.log(e.target)
        }
    }
});

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var edit = document.querySelectorAll(".fa-user-edit");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];


//var sub = document.getElementById("formSubmit");

//sub.onclick = function () {
//    debugger
//    // modal.style.display = "none";
//    // e.preventDefault();
//    let formPr = this.closest("form").getAttribute("name");
//    let formBox = this.closest("form").getAttribute("id");
//    let xForms = document.forms[formPr].querySelectorAll("input[required]");
//    let validCheck = true;
//    xForms.forEach(function (xForm) {
//        let formName = xForm.getAttribute("name");
//        let formX = document.forms[formPr][formName].value;

//        if (formX == "") {
//            validCheck = false;
//            // console.log(validCheck,1)
//        } else {
//            if (validCheck == false) {
//                validCheck = false;
//            } else {
//                validCheck = true;
//            }
//        }
//    });
//    // console.log(validCheck)
//    if  (validCheck == false ) {
//        Toast(2000, "warning");
//    } else {
//        debugger
//        Toast();
//        // modal.style.display = "none";
//        // return true;
//        let formName = document.getElementById(formBox);
//        setTimeout(() => {
//            formName.submit();
//        }, 3000);
//    }
//     //  var a = document.getElementById("snackbar");
//     //  a.className = "show";

//     //  setTimeout(function () {
//     //  a.className = a.className.replace("show", "");
//     //}, 3000);
//};

// When the user clicks the button, open the modal
btn.onclick = function () {
    modal.style.display = "block"
};
edit.forEach((each) => {
    each.addEventListener("click", () => {
        modal.style.display = "block";
    });
});

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
};

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

// dropdown----------------------------------------------------------------------------------
function myFunction() {
    var dropdown = document.getElementById("myDIV");

    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

function myFunctions() {
    var dropdown = document.getElementById("myDIVs");
    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const selector = ".nav__link";
    const elems = Array.from(document.querySelectorAll(selector));

    const navigation = document.querySelector("nav");

    function makeActive(evt) {
        const target = evt.target;

        if (!target || !target.matches(selector)) {
            return;
        }

        elems.forEach((elem) => elem.classList.remove("active"));

        evt.target.classList.add("active");
    }

    navigation.addEventListener("mouseup", makeActive);
});


// password show hide--------------------------------------------------------------------------------------------------------------------
function myPass() {
    var x = document.getElementById("myInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function myWord() {
    var x = document.getElementById("myInputs");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

var submitter = document.getElementById("formSubmit");

submitter.onclick = function submitter() {
    debugger
    // modal.style.display = "none";
    // e.preventDefault();
    let formPr = this.closest("form").getAttribute("name");
    let formBox = this.closest("form").getAttribute("id");
    let xForms = document.forms[formPr].querySelectorAll("input[required]");
    let validCheck;
    xForms.forEach(function (xForm) {
        let formName = xForm.getAttribute("name");
        let formX = document.forms[formPr][formName].value;

        if (formX == "") {
            validCheck = false;
            // console.log(validCheck,1)
        } else {
            if (validCheck == false) {
                validCheck = false;
            } else {
                validCheck = true;
            }
        }
    });
    // console.log(validCheck)
    if (validCheck == false || validCheck == undefined) {
        Toast(2000, "warning");
    } else {
        Toast();
        // modal.style.display = "none";
        // return true;
        let formName = document.getElementById(formBox);
        setTimeout(() => {
            formName.submit();
        }, 3000);
    }
    //   var a = document.getElementById("snackbar");
    //   a.className = "show";

    //   setTimeout(function () {
    //   a.className = a.className.replace("show", "");
    // }, 3000);
};
