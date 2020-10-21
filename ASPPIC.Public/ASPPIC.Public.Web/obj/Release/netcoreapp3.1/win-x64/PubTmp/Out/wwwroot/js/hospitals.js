$(document).ready(function () {

    //$('.filterTitle').click(function () {
    //    $(this).closest('.filterWrap').find('.hiddenFilter').stop(true, true).slideToggle('fast');
    //});


    var map = L.map('map', {
        'center': [45.7, 26.10626],
        'zoom': 7
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; ASPPIC-19'
    }).addTo(map);

    //L.esri.featureLayer({
    //    url: 'https://gissrv.asppic-19.geo-spatial.ro/spitale-provider/spitale/FeatureServer/0/query'
    //}).addTo(map);

    function getMarker(categorie) {
        var color;
        switch (categorie) {
            case 'DSP':
                color = 'yellow';
                break;
            case "TESTARE_COVID":
                color = 'violet';
                break;
            case "SUPORT_COVID":
                color = 'blue';
                break;
            case "SUPORT_COVID_MATERNITATE":
                color = 'gold';
                break;
            case "SPITAL_FAZA_1":
                color = 'orange';
                break;
            case "SPITAL_FAZA_2":
                color = 'red';
                break;
            case "SUPORT_COVID_DIALIZA":
                color = 'green';
                break;
            case "NON-COVID":
                color = 'grey';
                break;
        }
        var icon = new L.Icon({
            iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-' + color + '.png',
            shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
            iconSize: [25, 41],
            iconAnchor: [12, 41],
            popupAnchor: [1, -34],
            shadowSize: [41, 41]
        });

        return icon;
    }

    $.ajax({
        method: "GET",
        url: "https://stats.asppic-19.geo-spatial.ro/hospitals",
        success: function (response) {
            render(response)

        }
    })

    function render(hospitals) {
        hospitals.forEach((hospital) => {
            var lat = parseFloat(hospital["latitude"]);
            var lon = parseFloat(hospital["longitude"]);
            console.log(lon, lat);
            L.marker([lat, lon], {
                icon: getMarker(hospital["category"])
            }).addTo(map).on('click', function (e) {
                $("#hospitalModalTitle").empty().text(hospital["hospitalName"]);
                $("#hospitalImage").attr('src', hospital["logo"]);
                $("#hospitalAddress").text(hospital["address"] + ", " + hospital["uat"] + ", " + hospital["county"]);
                $("#hospitalEmail").text(hospital["email"]);
                $("#hospitalPhone").text(hospital["phone"]);
                $("#hospitalWebsite").attr('href', hospital["fullLink"]);
                $("#hospitalWebsite").text(hospital["fullLink"]);
                $("#stateHospital").text(hospital["statePrivate"])
                $("#hospitalRoute").attr('href', "http://maps.google.com/maps?daddr=" + hospital["latitude"] + "%2C" + hospital["longitude"]);
                $("#hospitalInfo").text(hospital["additionalData"]);
                $("#hospitalModal").modal('show');
            });
        });

        $('#hospitalModal').on('hide.bs.modal', function () {
            $("#hospitalImage").attr('src', "");
        })
    }
})