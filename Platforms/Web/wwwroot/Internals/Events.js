window.Hybrid = window.Hybrid || {};

// Events
window.Hybrid.events =
{
    queue: [],

    pushEvent: function(name) 
    {
        this.queue.push(name);
    },

    pollEvent: function() 
    {
        return this.queue.shift();
    }
};

// Resize
window.addEventListener("resize", () => 
{
    window.Hybrid.events.pushEvent("resize");
});