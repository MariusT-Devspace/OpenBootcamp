let map;
let currentLocationMarker;
let marker1, marker2, marker3;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
    center: { lat: -34.397, lng: 150.644 },
    zoom: 8,
    });

    currentLocationMarker = new google.maps.Marker({
    position: {lat: -34.397, lng: 150.644},
    map,
    title: "Starting position"
    });

    geoPosition();
    setMarkers();
}

function geoPosition(){
    if(navigator.geolocation) {
        const watchPosition = navigator.geolocation.watchPosition(centerMap, error => console.error(error), { timeout: 60000 });
    }else {
        alert("Your browser doesn't support geolocation");
    }
}

function centerMap(position) {
    const currentPosition = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
    }
    currentLocationMarker.setPosition(currentPosition);
    map.setCenter(currentPosition);
}

function setMarkers() {
    marker1 = new google.maps.Marker({
        map,
        position: {
            lat: 41.890072,
            lng: 12.492534
        },
        title: "Metropolitan City of Rome, Italy"
    });

    marker2 = new google.maps.Marker({
        map,
        position: {
            lat: 20.682526,
            lng: -88.568632
        },
        title: "Pyramid of Kukulcan, Chichén Itzá, Yuc., Mexico"
    });

    marker3 = new google.maps.Marker({
        map,
        position: {
            lat: 28.655931,
            lng: 77.238320
        },
        title: "Lal Qila, New Delhi, India"
    });
}

window.initMap = initMap;


