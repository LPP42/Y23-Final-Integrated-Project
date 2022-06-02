let PointServiceUrl = "https://localhost:7137/api/point";
let RouteServiceUrl = "https://localhost:7137/api/route";

mapboxgl.accessToken = "pk.eyJ1IjoibHBwNDIiLCJhIjoiY2wyYWZtNTFjMDUwMzNpcW50c3oyemp3aiJ9.EcrbBNeaSRbjO0IeCzlbnA";
let map;

let mapInit = async function () {

    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/lpp42/cl2ozenfq000c14p59ksrtw8j',
        center: [-75.787, 45.456],
        zoom: 12
    });
}
mapInit();
 
let route = {};

let markers = [];

function add_marker(event) {

    let marker = new mapboxgl.Marker();
    var coordinates = event.lngLat;
    console.log(coordinates);
    markers.push({ marker: marker, coordinates: coordinates });
    //console.log('Lng:', coordinates.lng, 'Lat:', coordinates.lat);

    console.log("marker:",marker);
    marker.setLngLat(coordinates).addTo(map);

    marker.getElement().addEventListener('click', function (e) {
        console.log(e);
        marker.remove();
        e.stopPropagation();
    });
}
map.on('click', add_marker);

let SaveRouteEl = document.getElementById('BtnSaveRoute');

SaveRouteEl.addEventListener('click', async function (e) {
    let routeNameEl = document.getElementById("routeName");
    let routeDifEl = document.getElementById("difBox");
    let routeLenEl = document.getElementById("lenBox");
    let difInt; let lenInt;
    switch(routeDifEl.value) {
    case "Beginner": difInt=0; break;
    case "Easy": difInt=1; break;
    case "Medium": difInt=2; break;
    case "Hard": difInt=3; break;
    case "Pro": difInt=4; break;
    }
    switch(routeLenEl.value) {
    case "Shortest": lenInt=0; break;
    case "Short": lenInt=1; break;
    case "Medium": lenInt=2; break;
    case "Long": lenInt=3; break;
    case "Longest": lenInt=4; break;
    }
    //console.log(difInt);
    //console.log(difficulty);
    let newRoute = { "Name": routeNameEl.value, "Difficulty": difInt, "Distance":lenInt }
    let newRouteData = fetch(RouteServiceUrl, {
        cache: 'no-cache',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Accept: 'application/json'
        },
        body: JSON.stringify(newRoute)
    });
    // let checkR = await fetch(RouteServiceUrl, {
    //     method: 'GET',
    //     // url: '@Url.Action("SomeAction", "ControllerName")',
    //     dataType: 'json',
    //     success: function (data) {
          
    //     }
    //     });
    //     console.log(checkR);
    let newRouteInfo = await newRouteData;
    let newRouteJson = await (await newRouteData).json();

    console.log(newRouteJson.routeId);

    let isFirst = true;
    let newPoint;
    markers.forEach((el) => {
        if (isFirst){
            console.log(isFirst);
            newPoint = { "Lat": el.coordinates.lat, "Lng": el.coordinates.lng,"RouteId": newRouteJson.routeId, "IsStart": true };
            isFirst=false;
            console.log(isFirst);
        } else {
            console.log("dsd");
            newPoint = { "Lat": el.coordinates.lat, "Lng": el.coordinates.lng,"RouteId": newRouteJson.routeId, "IsStart": false  }}
        console.log(newPoint);

        let newPointData = fetch(PointServiceUrl, {
            cache: 'no-cache',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Accept: 'application/json'
            },
            body: JSON.stringify(newPoint)
        });
    });
    window.location.href = '../Map/Add/';
});