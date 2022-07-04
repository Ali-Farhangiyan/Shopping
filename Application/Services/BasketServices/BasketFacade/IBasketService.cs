using Application.ImageServices.FacadeImage;
using Application.Interfaces;
using Application.Services.BasketServices.AddItemToBasket;
using Application.Services.BasketServices.GetBasketForUser;
using Application.Services.BasketServices.GetOrCreateBasketForUser;
using Application.Services.BasketServices.RemoveItemFromBasket;
using Application.Services.BasketServices.SetQuantityForBasketItem;
using Application.Services.BasketServices.TransferBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketServices.BasketFacade
{
    public interface IBasketService
    {
        IGetOrCreateBasketForUserService GetOrCreateBasket { get; }
        IAddItemToBasketService AddItem { get; }

        IRemoveItemFromBasketService RemvoeItem { get; }

        ISetQuantityForBasketItemService SetQuantity { get; }

        ITransferBasketService TransferBasket { get; }

        IGetBasketForUserService GetBasket { get; }
    }

    public class BasketService : IBasketService
    {
        private readonly IDatabaseContext db;
        private readonly IImageService imageService;

        public BasketService(IDatabaseContext db,
            IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }



        private IGetOrCreateBasketForUserService getOrCreateBasket;
        public IGetOrCreateBasketForUserService GetOrCreateBasket =>
            getOrCreateBasket ?? new GetOrCreateBasketForUserService(db,imageService);


        private IAddItemToBasketService addItem;
        public IAddItemToBasketService AddItem =>
            addItem ?? new AddItemToBasketService(db);


        private IRemoveItemFromBasketService remvoeItem;
        public IRemoveItemFromBasketService RemvoeItem =>
            remvoeItem ?? new RemoveItemFromBasketService(db);



        private ISetQuantityForBasketItemService setQuantity;
        public ISetQuantityForBasketItemService SetQuantity =>
            setQuantity ?? new SetQuantityForBasketItemService(db);



        private ITransferBasketService transferBasket;
        public ITransferBasketService TransferBasket =>
            transferBasket ?? new TransferBasketService(db);



        private IGetBasketForUserService getBasket;
        public IGetBasketForUserService GetBasket =>
            getBasket ?? new GetBasketForUserService(db, imageService);
    }
}
