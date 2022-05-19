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
    markers.push({ marker: marker, coordinates: coordinates });
    //console.log('Lng:', coordinates.lng, 'Lat:', coordinates.lat);
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

    let routeNameEl =  document.getElementById("routeName");
    //console.log(routeNameEl.value);

    let newRoute = {"Name":routeNameEl.value}
    let newRouteData = fetch(RouteServiceUrl, {
        cache: 'no-cache',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Accept: 'application/json'
        },
        body: JSON.stringify(newRoute)
    });

    markers.forEach((el) => {
        //console.log("lat:", el.coordinates.lat, "lng:", el.coordinates.lng);

        let newPoint = { "Lat": el.coordinates.lat, "Lng": el.coordinates.lng}
        //console.log(newPoint);

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
});