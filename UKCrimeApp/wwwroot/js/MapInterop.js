let map; // Holds the map instance

function loadMap() {
    if (!map) { // Check if the map has not been initialized
        map = L.map('map').setView([51.505, -0.09], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data © OpenStreetMap contributors',
            maxZoom: 18,
        }).addTo(map);
    } else {
        map.invalidateSize(); // Adjust the map size if the map container size changed
    }
}
