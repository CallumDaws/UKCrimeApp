export async function initializeMap(elementId, crimesJson) {
    const crimes = JSON.parse(crimesJson);
    console.log(crimes);

    // Assuming crimes is not empty and has the location property
    if (crimes.length > 0 && crimes[0].location) {
        const firstCrimeLat = parseFloat(crimes[0].location.latitude);
        const firstCrimeLon = parseFloat(crimes[0].location.longitude);

        // Initialize the map centered on the first crime
        const map = L.map(elementId).setView([firstCrimeLat, firstCrimeLon], 13);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data © OpenStreetMap contributors',
            maxZoom: 18,
        }).addTo(map);

        // Adding markers for each crime
        crimes.forEach(crime => {
            const { latitude, longitude } = crime.location;
            const { category } = crime;
            L.marker([parseFloat(latitude), parseFloat(longitude)]).addTo(map)
                .bindPopup(`<strong>Category:</strong> ${category}`);
        });
    } else {
        // Handle case where no crimes data is available
        console.log("No crimes data available to display on the map.");
    }
}
