

function TotalBedroomTemplate2(data) {
    switch (data.totalBedroom) {
        case "1":
            data.totalBedroom = "1 Bedroom";
            break;
        case "2":
            data.totalBedroom = "2 Bedroom";
            break;
        case "3":
            data.totalBedroom = "3 Bedroom";
            break;
        case "4":
            data.totalBedroom = "4 Bedroom";
            break;
        case "5+":
            data.totalBedroom = "5 Bedroom";
            break;
        default:

            break;
    }
    return data.totalBedroom == null ? "" : data.totalBedroom;
}

