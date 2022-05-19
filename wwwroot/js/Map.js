let todoServiceUrl = "https://localhost:7282/api/point";

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
    markers.push({ marker: marker, coordinates: coordinates });
    console.log('Lng:', coordinates.lng, 'Lat:', coordinates.lat);
    marker.setLngLat(coordinates).addTo(map);

    marker.getElement().addEventListener('click', function (e) {
        console.log(e);
        marker.remove();
        e.stopPropagation();
    });
}
map.on('click', add_marker);


let SaveRouteEl = document.getElementById('BtnSaveRoute');
SaveRouteEl.addEventListener('click', function (e) {
    markers.forEach((el) => {
        console.log("lat:", el.coordinates.lat, "lng:", el.coordinates.lng);

        PutPoint();

    });
});