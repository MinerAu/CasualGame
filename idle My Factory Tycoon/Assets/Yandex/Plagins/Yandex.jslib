mergeInto(LibraryManager.library, {

   PlayerData: function() {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
   },

   RateGame: function(){
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
   },

ShowAdv: function(){
   ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // Действие после закрытия рекламы.
           // SendMessage("Yandex", "AddCoins", coins)
        },
        onError: function(error) {
          // Действие в случае ошибки.
        }
    }
 })
},

});