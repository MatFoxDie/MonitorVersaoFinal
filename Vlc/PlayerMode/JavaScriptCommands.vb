Public Module JavaScriptCommands
    Public Function PlayPause() As String
        Dim command As String
        command = "
                var elemento = document.querySelector('[data-testid=""control-button-playpause""]');
                
                // Verifique se o elemento foi encontrado
                if (elemento) {
                    // Dispare o evento de clique no elemento
                    elemento.click();
                } else {
                    console.error('Elemento não encontrado com o atributo data-testid fornecido.');
                }
                
                "
        Return command
    End Function

    'Public Function PlayGreenButton() As String
    '    Dim command As String
    '    command = "
    '            var elemento = document.querySelector('[data-testid=""play-button""]');

    '            // Verifique se o elemento foi encontrado
    '            if (elemento) {
    '                // Dispare o evento de clique no elemento
    '                elemento.click();
    '            } else {
    '                console.error('Elemento não encontrado com o atributo data-testid fornecido.');
    '            }

    '            "

    '    Return command
    'End Function

    Public Function PlayGreenButton() As String
        Dim command As String
        command =
            "
            // Definir uma função para verificar se o botão foi adicionado ao DOM
            function verificarBotao() {
                // Encontre o elemento pelo atributo data-testid
                var elemento = document.querySelector('[data-testid=""play-button""]');
            
                // Verifique se o elemento foi encontrado
                if (elemento) {
                    // Dispare o evento de clique no elemento
                    elemento.click();
                } else {
                    // Se o elemento não foi encontrado, aguarde um curto período de tempo e verifique novamente
                    setTimeout(verificarBotao, 1000); // Verifique novamente após 1 segundo (1000 milissegundos)
                }
            }
            
            // Chamar a função verificarBotao pela primeira vez para iniciar o loop
            verificarBotao();


                    "
        Return command
    End Function

    Public Function SkipToNext() As String
        Dim command As String
        command = "
                var elemento = document.querySelector('[data-testid=""control-button-skip-forward""]');
                
                // Verifique se o elemento foi encontrado
                if (elemento) {
                    // Dispare o evento de clique no elemento
                    elemento.click();
                } else {
                    console.error('Elemento não encontrado com o atributo data-testid fornecido.');
                }
                
                "
        Return command
    End Function

    Public Function SkipToPrevious() As String
        Dim command As String
        command = "
                var elemento = document.querySelector('[data-testid=""control-button-skip-back""]');
                
                // Verifique se o elemento foi encontrado
                if (elemento) {
                    // Dispare o evento de clique no elemento
                    elemento.click();
                } else {
                    console.error('Elemento não encontrado com o atributo data-testid fornecido.');
                }
                
                "
        Return command
    End Function

    Friend Function PlayTrack(TrackName As String) As String
        Dim command As String
        command = "
                function encontrarEClicarBotao(textoParcial) {
                  // Cria um seletor CSS que combina com o texto parcial da aria-label
                  const seletorCSS = `button[aria-label*=""${textoParcial}""]`;
                
                  // Encontra o botão usando o seletor CSS
                  const botao = document.querySelector(seletorCSS);
                
                  // Se o botão for encontrado, clique nele
                  if (botao) {
                    botao.click();
                  } else {
                    console.warn(`Nenhum botão encontrado com o texto ""${textoParcial}""`);
                  }
                }
                
                // Exemplo de uso
                encontrarEClicarBotao(""Tocar Me Leva Pra Casa"");

                    "
        Return command
    End Function


    Public Function Sair() As String
        Dim command As String
        command = "
                function clickButtonsInOrder() {
                  // Select the first button using its data-testid attribute
                  const firstButton = document.querySelector('[data-testid=""user-widget-link""]');
                
                  // Check if the first button is found
                  if (firstButton) {
                    // Click the first button
                    firstButton.click();
                
                    // Wait for some time (optional) to ensure the dropdown opens before clicking the second button
                    setTimeout(() => {
                      // Select the second button using its data-testid attribute
                      const secondButton = document.querySelector('[data-testid=""user-widget-dropdown-logout""]');
                
                      // Check if the second button is found
                      if (secondButton) {
                        // Click the second button
                        secondButton.click();
                      } else {
                        console.warn(""Second button not found."");
                      }
                    }, 100); // Adjust the wait time if needed (in milliseconds)
                  } else {
                    console.warn(""First button not found."");
                  }
                }
                
                // Call the function to click the buttons
                clickButtonsInOrder();
                    "

        Return command
    End Function
End Module
