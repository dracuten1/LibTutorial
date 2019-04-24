using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibTutorial.Components {
    public abstract class BaseComponent:ViewComponent{
        public BaseComponent(IMediator mediator) {
            Mediator = mediator;
        }
        public IMediator Mediator { get; }
    }
}
