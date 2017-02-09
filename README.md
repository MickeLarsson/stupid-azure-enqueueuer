# Stupid Azure Enqueueuer
Takes the hassle out of enqueueing simple string messages on a Azure queue.

Great when you only need to push a simle string, or a dynamic object on a queue, and then forget about it.
![](http://i.giphy.com/65NO1TrKrJUT6.gif "Forget about it")

```
var enqueueuer = new StupidEnqueueuer(CLOUD_STORAGE_ACCOUNT_CONNECTION_STRING);
var queueName = "stuff";
enqueueuer.Enqueue(queueName, "howdy");
```
