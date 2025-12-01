window.Hybrid = window.Hybrid || {};

window.Hybrid.events = {
    queue: [],

    pushEvent: function(name) {
        this.queue.push(name);
    },

    pollEvent: function() {
        return this.queue.shift();
    }
};

// Resize Event
window.addEventListener("resize", () => 
{
    window.Hybrid.events.pushEvent("resize");
});