

function openForm() {
    if (document.getElementById('myForm')) {
        document.getElementById('myForm').style.display = " block";
        document.getElementById('myForm').classList.add("opened");
    }
} function closeForm() {
    if
        (document.getElementById('myForm')) {
        document.getElementById('myForm').style.display = "none";
        document.getElementById('myForm').classList.remove("opened");
    }
} function
    validateForm() {
        let x = document.forms["user-form"]["fname"].value; if (x == "") {
            alert("Name must be filled out"); return false;
        }
} let
    y = document.querySelector(".iconImage span"); let x = document.querySelector(".closebtn");
// let z=document.querySelector(".open-button"); // console.log('open-button')
y.addEventListener('click', () => {
    // z.classList.add("showbar");
    document.querySelector(".sidenav").classList.add('showbar');

});
x.addEventListener('click', () => {
    // z.classList.add("showbar");
    document.querySelector(".sidenav").classList.remove('showbar');

});
window.addEventListener('click', function (e) {
    // console.log(e.target.parentElement)
    var element = document.getElementById('myForm');
    var imgItm = document.querySelector('.imgContainer img');

    if (e.target !== element && !element.contains(e.target)) {
        if (element.classList.contains("opened") && e.target !== imgItm) {
            closeForm()
            // console.log(e.target)
        }
    }
})

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var edit = document.querySelectorAll(".fa-user-edit")

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
//
var sub = document.getElementById("submit");
sub.onclick = function () {
    modal.style.display = "none";
    var a = document.getElementById("snackbar");
    a.className = "show";
    setTimeout(function () {
        a.className = a.className.replace("show", "");
    }, 3000);
}

// When the user clicks the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}
edit.forEach((each)=>{
    each.addEventListener('click',()=>{
        modal.style.display = "block";


    })

})

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

