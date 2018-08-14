const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const Types = Schema.Types;

var genreSchema = Schema({
    title: { type: Types.String, required: true, unique: true },
    memes: [{ type: Types.ObjectId, ref: "Meme" }]
});

var Genre = mongoose.model("Genre", genreSchema);

module.exports = Genre;
