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

let routeId = document.getElementById("routeId").textContent;
PointServiceUrl += "/route/" + routeId;
console.log(PointServiceUrl);

let markers = [];

async function showRoute() {
    //console.log("function showRoute");

    let routePoints = fetch(PointServiceUrl, {
        cache: 'no-cache',
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Accept: 'application/json'
        },
    });
    //console.log(routePoints);
    let routePointsJson = await (await routePoints).json();
    //console.log(routePointsJson);

    routePointsJson.forEach(el => {
        if (el.isStart==true) {
            let marker = new mapboxgl.Marker({ "color": "#b20456" }).setLngLat([el.lng, el.lat]).setPopup(new mapboxgl.Popup().setHTML(`Starting Point`)).addTo(map).togglePopup();
            let coordinates = {};
            //console.log(el);
            coordinates = { lng: el.lng, lat: el.lat };
            markers.push({ marker: marker, coordinates: coordinates });
        } else {
            let marker = new mapboxgl.Marker();
            let coordinates = {};
            //console.log(el);
            coordinates = { lng: el.lng, lat: el.lat };
            markers.push({ marker: marker, coordinates: coordinates });
        }
    });
    //console.log("Markers: ", markers);

    markers.forEach(el => {
        //console.log(el);
        el.marker.setLngLat(el.coordinates).addTo(map);
    });
}
showRoute();


