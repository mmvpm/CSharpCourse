using EventBus;

var subA = new SubscriberA();
var subB = new SubscriberB();

var pubA = new PublisherA();
var pubB = new PublisherB();

var eventBus = new EventBus.EventBus();
eventBus.AddPublisher("pubA", pubA);
eventBus.AddPublisher("pubB", pubB);

eventBus.Subscribe("pubA", subA);
eventBus.Subscribe("pubB", subA);
eventBus.Subscribe("pubA", subB);
eventBus.Subscribe("pubB", subB);

pubA.Post();
/* Output:
    PublisherA.Post()
    SubscriberA.OnEvent()
    SubscriberB.OnEvent()
*/

pubB.Post();
/* Output:
    PublisherB.Post()
    SubscriberA.OnEvent()
    SubscriberB.OnEvent()
*/

eventBus.RemovePublisher("pubA");
pubA.Post();
/* Output:
    PublisherA.Post()
*/

eventBus.Unsubscribe("pubB", subA);
pubB.Post();
/* Output:
    PublisherB.Post()
    SubscriberB.OnEvent()
*/