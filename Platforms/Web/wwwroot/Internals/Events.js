window.HybridJS = window.HybridJS || {};

window.HybridJS.events =
{
    queue: [],

    PushEvent: function(name) 
    {
        this.queue.push(name);
    },

    PollEvent: function() 
    {
        return this.queue.shift();
    }
};

// Resize
window.addEventListener("resize", () => 
{
    window.HybridJS.events.PushEvent("resize");
});