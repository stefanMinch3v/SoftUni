function cone(r, h) {
    let area = Math.PI * r * (r + Math.sqrt(r * r + h * h));
    let volume = (1.0 / 3) * Math.PI * r * r * h;

    console.log(volume.toFixed(4));
    console.log(area.toFixed(4));
}

cone(3, 5);