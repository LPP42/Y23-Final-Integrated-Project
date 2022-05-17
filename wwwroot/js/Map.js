console.log("Running Map.js");

mapboxgl.accessToken = "pk.eyJ1IjoibHBwNDIiLCJhIjoiY2wyYWZtNTFjMDUwMzNpcW50c3oyemp3aiJ9.EcrbBNeaSRbjO0IeCzlbnA";
let map;

let mapInit = async function () {
    
    let url = "http://localhost:3000/api";

    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/lpp42/cl2ozenfq000c14p59ksrtw8j',
        center: [-75.787, 45.456],
        zoom: 12
    });
}

mapInit();

