

let reservation ;




var weekday = new Array(7);
weekday[0] = "Dimanche";
weekday[1] = "Lundi";
weekday[2] = "Mardi";
weekday[3] = "Mercredi";
weekday[4] = "Jeudi";
weekday[5] = "Vendredi";
weekday[6] = "Samedi";



function GetReservation() {
    $.ajax({
     url: '/reservations/res',
     type: 'GET',
     dataType: 'json',

     contentType: 'application/json',
     success: function (data) {
         reservation = data;
         loadcal();
     },
     error: function (err) {
         alert(err.status + " : " + err.statusText);
     }
 });


}

GetReservation()

const days = document.querySelectorAll(".calandrier div");
const nextWeek = document.querySelector(".next");
const previousWeek = document.querySelector(".previous");
const dateInfo = document.querySelector(".num-date");
const dayInfo = document.querySelector(".num-day");
const TypeInfo = document.querySelector(".num-jour");
const submitBtn = document.querySelector(".submit-btn");


let targetReservation;
let targetDate;
let targetType;
let targetId;
let currentDate = new Date();

if (currentDate.getDay() == 0) {
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() - 7);
}

nextWeek.addEventListener("click", (e) => {

    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 7);
    loadcal();
})
previousWeek.addEventListener("click", (e) => {
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() - 7);
    loadcal();
})


function loadcal() {



    let date = currentDate;
    if (currentDate.getDay() == 0) {
        date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 7);
    }

    dateInfo.innerHTML = date.getDate();
    dayInfo.innerHTML = weekday[date.getDay()];

    days.forEach((day, index) => {

        if (day.classList.contains("jour")) {
            return;
        }

        let test = day.children[0];

        day.innerHTML = "";

        day.appendChild(test);

        var x;
        var y;
        day.setAttribute("day", index == 7 ? 0 : index)

        if (day.classList.contains("sam") || day.classList.contains("dim")) {
            x = document.createElement('span');
            x.classList.add("weekend");
            x.addEventListener("click", Reserver)
            day.appendChild(x);

        } else {

            x = document.createElement('span');
            x.classList.add("Day");
            x.addEventListener("click", Reserver)
            day.appendChild(x);
            y = document.createElement('span');
            y.classList.add("evening");
            y.addEventListener("click", Reserver)
            day.appendChild(y);
        }

        reservation.forEach(res => {
            let date = new Date(res["date"]);

            let first = day.classList.contains("dim") ? currentDate.getDate() - currentDate.getDay() + 7 : currentDate.getDate() - currentDate.getDay();

            if (date.getDate() - date.getDay() == first) {

                if (date.getDay() == day.getAttribute("day")) {

                    if (res['reservationType']['type'] == 'evening') {

                        y.classList.add("active")
                        y.setAttribute("id", res["id"])
                        if (res['isValid']) {
                            y.classList.add("valid")
                        }

                    } else {
                        x.classList.add("active")
                        x.setAttribute("id", res["id"])
                        if (res['isValid']) {
                            x.classList.add("valid")
                        }
                    }

                    

                    

                }

            }
        })


    })

}


function getMonday(d) {
    d = new Date(d);
    var day = d.getDay(),
        diff = d.getDate() - day + (day == 0 ? -6 : 1); // adjust when day is sunday
    return new Date(d.setDate(diff));
}


function Reserver(e) {

    targetReservation = e.target;
    let day = parseInt(targetReservation.parentElement.getAttribute("day"))
    console.log(targetReservation.parentElement.getAttribute("day"));

    let date = getMonday(currentDate);

    //let date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + (day == 0 ? 6 : day - 1));
    date = new Date(date.getFullYear(), date.getMonth(), date.getDate() + (day == 0 ? 6 : day - 1));

    targetDate = date;



    if (targetReservation.classList.contains("evening")) {
        TypeInfo.innerHTML = "Soir";
        targetType = "evening";
    } else if (targetReservation.classList.contains("weekend")) {

        TypeInfo.innerHTML = "week-end";
        targetType = "weekend";

    } else {
        TypeInfo.innerHTML = "Jour";
        targetType = "day";
    }



    dateInfo.innerHTML = date.getDate();
    dayInfo.innerHTML = weekday[date.getDay()];
    TypeInfo.classList.add('active')

    if (role == "admin") {

        submitBtn.innerHTML = "Afficher la liste"
        submitBtn.addEventListener("click", ViewList)
      

    } else {

        if (e.target.classList.contains("active")) {
            submitBtn.innerHTML = "Delete"
            submitBtn.classList.add('delete')
            submitBtn.addEventListener("click", Delete)
            submitBtn.removeEventListener("click", SubmitReservation)
            targetId = e.target.getAttribute("id")
        } else {
            submitBtn.innerHTML = "Reserver"
            submitBtn.classList.remove('delete')
            submitBtn.removeEventListener("click", Delete)
            submitBtn.addEventListener("click", SubmitReservation)

        }

        

    }

    submitBtn.classList.add('active')

}

function SubmitReservation(e) {

    this.classList.remove('active')
    TypeInfo.classList.remove('active')

    $.ajax({
        url: '/Reservations/Create',
        type: 'Post',
        contentType: 'application/x-www-form-urlencoded',

        data: {

            date: targetDate.toJSON(),
            type: targetType

        },
        success: function (data) {
            reservation = data;
            loadcal();

        },
        error: function (err) {
            alert(err.status + ": error : " + err.responseText);
        }
    });


}
function Delete(e) {

    this.classList.remove('active')
    TypeInfo.classList.remove('active')


    $.ajax({
        url: '/Reservations/Delete',
        type: 'Post',
        contentType: 'application/x-www-form-urlencoded',

        data: {

            id : targetId

        },
        success: function (data) {
            reservation = data;
            loadcal();

        },
        error: function (err) {
            alert(err.status + ": error : " + err.responseText);
        }
    });

}
 
function ViewList(e) {


    window.location.href = '/reservations?date=' + targetDate.toJSON()+'&type=' + targetType;
    console.log("test")

}