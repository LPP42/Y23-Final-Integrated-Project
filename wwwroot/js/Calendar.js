
    function twoDigiter(n){return n<10? '0'+n:''+n;}
    const convert1224 = (t12) => {
        const [time, modifier] = t12.split(' ');
      
        let [hours, minutes, secs] = time.split(':');
      
        if (hours === '12') {
          hours = '00';
        }
      
        if (modifier === 'PM') {
          hours = parseInt(hours, 10) + 12;
        }
      
        return `${twoDigiter(hours)}:${twoDigiter(minutes)}`;
    }

    let eventsArr = [];
        let todoTable = document.getElementById("todoTable");
        //let trBody = todoTable.getElementsByTagName("tbody");
        let trElem = todoTable.getElementsByClassName("trl");
        //console.log(trElem);
        for (let tr of trElem) {
            //console.log(tr);
            let tdElems = tr.getElementsByTagName("td");
            let splitted =tdElems[2].innerText.split(" ");
            let sdate = splitted[0].split("/");
            let year;
            let day;
            let month;
            // console.log(splitted[0]);
            // console.log(sdate[1]);
            if (sdate[1]=="undefined") {
                sdate = splitted[0].split("-");
                day = twoDigiter(sdate[2]);
                month = twoDigiter(sdate[1]);
                year = sdate[0];
            } else {
            day = twoDigiter(sdate[1]);
            month = twoDigiter(sdate[0]);
            year = sdate[2];
            }
            let hrs =convert1224(splitted[1]+" "+splitted[2]);
            //console.log(splitted[1]);
            let eventObj = {
                id: tdElems[0].innerText,
                title: tdElems[1].innerText,
                start: year+"-"+month+"-"+day+" "+hrs,
            }
            eventsArr.push(eventObj);
        }
        console.log(eventsArr);
        let calendarEl = document.getElementById('calendar');
        let calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: eventsArr,
       
        eventClick: function(calEvent, jsEvent, view) {
            //console.log(calEvent.event._def.publicId);
            window.location = "./Hike/Details?id=" + calEvent.event._def.publicId;
    
        },
        
        // events: [
        //     {
        //         title:"dsfsdfsd",
        //         start:"2022-05-22",
        //     },
        // ],
    });
    calendar.render();
