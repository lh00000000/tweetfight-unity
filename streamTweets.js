var http = require('http').Server(require('express')())
var io = require("socket.io")(http)
var Twit = require("twit")

const twitterCredentials = require("twitterCreds") // get ur own, punk

const stream = findStr => {
  const T = new Twit(twitterCredentials)
  return T.stream(
    "statuses/filter",
    {track:findStr},
    console.log)
}

stream(":(").on('tweet', tweet => io.emit("sadtweet", tweet))
stream(":)").on('tweet', tweet => io.emit("happytweet", tweet))

io.on("connection", socket => console.log("user connected" + socket.id))
http.listen(3000, () => console.log("listening on *:3000"))